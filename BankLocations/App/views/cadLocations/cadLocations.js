(function () {
    'use strict';

    angular
        .module('app')
        .controller('cadLocations', cadLocations);

    cadLocations.$inject = ['$scope', '$http', 'canvas'];

    function cadLocations($scope, $http, canvas) {

        const locationPrefix = 'Location';
        const bankPrefix = 'Bank';
        const zonePrefix = 'Zone';
        const sitePrefix = 'Site';

        $scope.sites = [];
        $scope.activeSite;

        $scope.zones = [];
        $scope.zonesTree = [];
        $scope.selectedBank;

        $scope.vendors = [];


        var treeReady;
        var canvasContext;

        var siteImage = $("img");
        $scope.siteImage = siteImage;

        var canvasElem = document.getElementById("canvas");

        $scope.$watch(function () {
            return $scope.siteImage.attr("src");
        }, function () {
            setTreeHeight();
            var maxHeight = $(".locations").height();

            if (siteImage.height() < maxHeight) {
                siteImage.height(maxHeight);
            }

            canvasElem.width = siteImage.width();
            canvasElem.height = siteImage.height();
        })

        getData();
        function getData() {
            $http.get("/api/Sites").then(function (response) {
                $scope.sites = response.data;
                if ($scope.sites.length > 0) {
                    $scope.activeSite = $scope.sites[0];
                    setTreeParent();
                    getZonesForSite();
                }

                console.log($scope.activeSite);
            });

            $http.get('/api/CadVendors').then(function (response) {
                $scope.vendors = response.data;
            })

        }

        $scope.onSiteChange = function () {
            setTreeParent();
            getZonesForSite();
        }

        $scope.updateVendor = function (selectedBank) {
            console.log(selectedBank);
            $http.post('/api/Zones?siteId=' + $scope.activeSite.SiteId, selectedBank).then(function () {
                $scope.selectedBank = null;
                $scope.onSiteChange();
            })
        }

        function setTreeParent() {
            if ($scope.activeSite) {
                $scope.zonesTree = [];
                var parent = {
                    id: sitePrefix + $scope.activeSite.SiteId,
                    parent: '#',
                    text: $scope.activeSite.SiteName,
                    state: { opened: true }
                }
                $scope.zonesTree.push(parent);
            }
        }

        function getZonesForSite() {
            if ($scope.activeSite) {

                $http.get("/api/Zones?siteId=" + $scope.activeSite.SiteId).then(function (response) {

                    var zones = response.data;
                    console.log(zones);
                    angular.forEach(zones, function (zone) {
                        var obj = {
                            id: zonePrefix + zone.ZoneId,
                            parent: sitePrefix + $scope.activeSite.SiteId,
                            text: zone.ZoneName,
                            data: zone
                        };

                        $scope.zonesTree.push(obj);

                        if (zone.Banks) {
                            angular.forEach(zone.Banks, function (bank) {
                                var bankObj = {
                                    id: bankPrefix + bank.BankId,
                                    parent: zonePrefix + zone.ZoneId,
                                    text: bank.BankNumber,
                                    data: bank
                                }

                                if (bank.VendorName) {
                                    bankObj.text += " (" + bank.VendorName + ")";
                                };

                                $scope.zonesTree.push(bankObj);

                                if (bank.Locations) {
                                    angular.forEach(bank.Locations, function (location) {
                                        var locObj = {
                                            id: locationPrefix + location.LocationId,
                                            parent: bankPrefix + bank.BankId,
                                            text: location.LocationNumber + " (" + location.PositionX + "," + location.PositionY + ")",
                                            data: location
                                        }
                                        $scope.zonesTree.push(locObj);
                                    })
                                }
                            });
                        }
                    });

                    //console.log($scope.zonesTree);
                    $scope.treeConfig.version++;
                });

            }
        }

        $scope.treeInstance;
        $scope.treeConfig = {
            core: {
                themes: {
                    name: 'proton',
                    responsive: true
                },
                multiple: true
            },
            version: 1
        };

        $scope.treeEvents = {
            ready: function () {
                treeReady = true;
                console.log('treeReady');
            },
            select_node: function (ev, node) {
                $scope.selectedBank = null;
                canvas.clear();
                processNode(node);
            }
        }

        initElements();
        function initElements() {

            setTreeHeight();

            var locationsWrapper = $(".locations");

            canvasContext = canvasElem.getContext('2d');

            //canvasElem.width = locationsWrapper.width();
            //canvasElem.height = locationsWrapper.height();


            canvas.init(canvasElem, canvasContext);
        }

        function setTreeHeight() {
            var sidebar = $(".sidebar");
            var sites = $(".sites");

            var tree = $(".tree");
            var treeHeight = sidebar.height() - sites.height();

            tree.css("max-height", treeHeight + "px");
            tree.css("height", treeHeight + "px");

        }

        function processNode(node) {
            console.log(node);
            if (node) {
                var data = node.node.data;
                node = node.node;

                if (node.id.startsWith(locationPrefix)) {

                    drawLocation(data);
                }
                else if (node.id.startsWith(bankPrefix)) {
                    $scope.selectedBank = data;
                    drawBank(data);
                }
                else if (node.id.startsWith(zonePrefix)) {
                    drawZone(data);
                }
            }
        }

        function drawLocation(location) {
            var loc = angular.copy(location);
            loc.PositionX = fn_CalculatePixelPositionX(siteImage.prop('naturalWidth'), siteImage.width(), $scope.activeSite.ImageWidthCadUnits, location.PositionX);
            loc.PositionY = fn_CalculatePixelPositionY(siteImage.prop('naturalHeight'), siteImage.height(), $scope.activeSite.ImageHeightCadUnits, location.PositionY);
            canvas.drawCircle(loc);
        }

        function drawBank(bank) {
            if (bank.Locations) {
                for (var location of bank.Locations) {
                    drawLocation(location);
                }
            }
        }

        function drawZone(zone) {
            if (zone.Banks) {
                for (var bank of zone.Banks) {
                    drawBank(bank);
                }
            }
        }

        function fn_CalculatePixelPositionX(OriginalImageWidthPixels, CurrentImageWidthPixels, ImageWidthInCadUnits, PositionX) {
            var OriginalPixelsPerCadUnit = OriginalImageWidthPixels / ImageWidthInCadUnits; //This is the scale = 1000/100=10
            var PixelsX = PositionX * OriginalPixelsPerCadUnit; //This is the location if image size didn't change = 10 * 75 = 750
            PixelsX = PixelsX * CurrentImageWidthPixels / OriginalImageWidthPixels; //Reduce by percentage image decreased in size = 750 * 550/1000 = 412.5 = 413 pixels
            return PixelsX;
        }

        function fn_CalculatePixelPositionY(OriginalImageHeightPixels, CurrentImageHeightPixels, ImageHeightInCadUnits, PositionY) {
            var OriginalPixelsPerCadUnit = OriginalImageHeightPixels / ImageHeightInCadUnits; //This is the scale  = 1000/100=10
            var PixelsY = PositionY * OriginalPixelsPerCadUnit; //This is the location if image size didn't change  = 10 * 25 = 250
            PixelsY = PixelsY * CurrentImageHeightPixels / OriginalImageHeightPixels; //Reduce by percentage image decreased in size = 250 * 550/1000 = 137.5 = 138 pixels
            return PixelsY;
        }

    }
})();

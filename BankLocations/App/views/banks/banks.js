(function () {
    'use strict';

    angular
        .module('app')
        .controller('banks', banks);

    banks.$inject = ['$scope', '$http', 'canvas'];

    function banks($scope, $http, canvas) {

        const locationPrefix = 'Location';
        const bankPrefix = 'Bank';
        const zonePrefix = 'Zone';
        const sitePrefix = 'Site';

        $scope.sites = [];
        $scope.activeSite;

        $scope.zones = [];
        $scope.zonesTree = [];

        var treeReady;
        var canvasContext;

        getSites();
        function getSites() {
            $http.get("/api/Sites").then(function (response) {
                $scope.sites = response.data;
                if ($scope.sites.length > 0) {
                    $scope.activeSite = $scope.sites[0];
                    setTreeParent();
                    getZonesForSite();
                }

                console.log($scope.activeSite);

            });
        }

        $scope.onSiteChange = function () {
            console.log($scope.activeSite);
            setTreeParent();
            getZonesForSite();
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

                                $scope.zonesTree.push(bankObj);

                                if (bank.Locations) {
                                    angular.forEach(bank.Locations, function (location) {
                                        var locObj = {
                                            id: locationPrefix + location.LocationId,
                                            parent: bankPrefix + bank.BankId,
                                            text: locationPrefix + location.LocationNumber,
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
                canvas.clear();
                processNode(node);
            }
        }

        initElements();
        function initElements() {
            var sidebar = $(".sidebar");
            var sites = $(".sites");
            var locationsWrapper = $(".locations");
            var tree = $(".tree");
            var treeHeight = sidebar.height() - sites.height();

            tree.css("max-height", treeHeight + "px");
            tree.css("height", treeHeight + "px");

            var canvasElem = document.getElementById("canvas");
            canvasContext = canvasElem.getContext('2d');

            canvasElem.width = locationsWrapper.width();
            canvasElem.height = locationsWrapper.height();


            canvas.init(canvasElem, canvasContext);
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
                    drawBank(data);
                }
                else if (node.id.startsWith(zonePrefix)) {
                    drawZone(data);
                }
            }
        }

        function drawLocation(location) {
            canvas.drawCircle(location);
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
    }
})();

(function () {
    'use strict';

    angular
        .module('app')
        .controller('cadVendor', cadVendor);

    cadVendor.$inject = ['$scope','$http','$uibModal'];

    function cadVendor($scope, $http, $uibModal) {
        
        $scope.vendors = [];
        $scope.selectedVendor;

        getData();
        function getData() {
            $http.get('/api/CadVendors').then(function (response) {
                $scope.vendors = response.data;
            })
        }

        $scope.openModal = function (vendor) {
            $scope.selectedVendor = vendor;
            var modalInstance = $uibModal.open({
                templateUrl: 'App/views/cadVendor/cadVendorCreate/cadVendorCreate.html',               
                controller: 'cadVendorCreate',
                resolve: {
                    vendor: angular.copy(vendor)
                }
            });

            modalInstance.result.then(function (res) {
                //$scope.selectedVendor = angular.extend($scope.selectedVendor, res);
                getData();
            });
        }

        $scope.delete = function (vendor, idx) {
            $scope.vendors.splice(idx, 1);
            $http.delete('/api/CadVendors/' + vendor.VendorId).then(function () {

            })
        }

    }
})();

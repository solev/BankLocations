(function () {
    'use strict';

    angular
        .module('app')
        .controller('cadVendorCreate', cadVendorCreate);

    cadVendorCreate.$inject = ['$scope', '$http', '$uibModalInstance', 'vendor'];

    function cadVendorCreate($scope, $http, $uibModalInstance, vendor) {

        $scope.colors = ['Red', 'Orange', 'Yellow', 'Blue', 'Black', 'Green'];
        $scope.vendor = vendor;
        $scope.model = angular.copy(vendor);
        $scope.saving = false;
        $scope.forms = {};
        $scope.close = function () {
            $uibModalInstance.dismiss();
        }

        $scope.save = function () {
            $scope.saving = true;
            if ($scope.model) {
                if ($scope.model.VendorId == null) {
                    $http.post('/api/CadVendors', $scope.model).then(function (response) {
                        $scope.saving = false;
                        $uibModalInstance.close(response.data);
                    })
                }
                else {
                    $http.put('/api/CadVendors/' + $scope.model.VendorId, $scope.model).then(function (response) {
                        $scope.saving = false;
                        $uibModalInstance.close(response.data);
                    })
                }
            }
        }
    }

})();

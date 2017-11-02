(function () {
    'use strict';

    angular
        .module('app')
        .controller('cadVendor', cadVendor);

    cadVendor.$inject = ['$scope','$http'];

    function cadVendor($scope, $http) {

        $scope.vendors = [
            {
                VendorId: 1,
                VendorName: 'Vendor01',
                VendorAbbreviation: 'V1'
            },
            {
                VendorId: 2,
                VendorName: 'Vendor02',
                VendorAbbreviation: 'V2'
            },
            {
                VendorId: 3,
                VendorName: 'Vendor03',
                VendorAbbreviation: 'V3'
            },
            {
                VendorId: 4,
                VendorName: 'Vendor04',
                VendorAbbreviation: 'V4'
            },
            {
                VendorId: 5,
                VendorName: 'Vendor05',
                VendorAbbreviation: 'V5'
            }
        ];
    }
})();

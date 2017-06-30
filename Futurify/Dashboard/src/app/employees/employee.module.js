(function () {
    'use strict';

    angular
        .module('app.employee', [])
        .config(['$stateProvider', function ($stateProvider) {
            // State
            $stateProvider
                .state('app.employee', {
                    url: '/employee',
                    controller: 'EmployeeController as vm',
                    templateUrl: 'app/employees/views/EmployeeList.html'
                });
            
        }]);


})();
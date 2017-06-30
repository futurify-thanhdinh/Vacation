(function () {
    'use strict';

    angular
        .module('app.employee')
        .controller('EmployeeController', function ($scope) {
            $scope.listEmployees = [
                { Id: 1, Name: "thanh dinh", address: "adlaskjdalsjd" },
                { Id: 1, Name: "nhan pham", address: "adlaskjdalsjd" },
                { Id: 1, Name: "tan hoang", address: "adlaskjdalsjd" }
            ];
        });
        
         

    
})();
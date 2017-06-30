'use strict';

var init_module = [
    'ngCountryStateSelect'
];

var app = angular.module('app', init_module)
    .controller('mainCtrl',function($scope){
        console.log('Your in the main Controller');
        $scope.countryview='<div ng-model="vm.selectedFamilyMember" country-select></div>';
        $scope.stateview='<div country="{{ vm.selectedFamilyMember }}" ng-model="vm.state" state-select></div>';
    });

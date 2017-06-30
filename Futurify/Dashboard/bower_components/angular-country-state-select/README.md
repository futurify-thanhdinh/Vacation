# angularjs-country-state-select
An angularjs directive package for selecting country and display its corresponding state. Credits to Abhishek Kaushik.

by <a href="http://www.efrenbautista.com">Efren Bautista Jr</a>


# How to install
Install usering bower:

bower install angular-country-state-select --save<br><br>

Add to your app:

ngCountryStateSelect

# Usage
```html
<div ng-model="vm.country" country-select></div>
<div country="{{ vm.country }}" ng-model="vm.state" state-select></div>
```

# Upcoming Updates
1. Use country codes
2. Add SQL country codes and states
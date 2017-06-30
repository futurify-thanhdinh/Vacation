(function () {
    'use strict';

    angular
        .module('vacation').constant('SVCS', {
            Auth: 'http://localhost:60600',
            Profile: 'http://localhost:60601',
            RVListing: 'http://localhost:60603',
            Booking: 'http://localhost:60000',
            Notification: 'http://localhost:60604',
            Payment: 'http://localhost:60605',
            Calendar: 'http://localhost:48018'
        });
})();

(function () {
    'use strict';

    angular.module('app', ['locationModule', 'uiGmapgoogle-maps']);

    angular.module('app').config(function (uiGmapGoogleMapApiProvider) {
        uiGmapGoogleMapApiProvider.configure({
            //key: 'get a key at https://console.developers.google.com'
            key: 'AIzaSyChoRWbL0V1ouvBeAbeIfwq3a5DwiH8KKA'
            // v: '3.20', //defaults to latest 3.X anyhow
            // libraries: 'weather,geometry,visualization'
        });
    });

    var controllerId = 'home';

    angular.module('app').controller(controllerId, homeController);

    homeController.$inject = ['$q', '$scope', '$timeout', 'locationRepository', 'uiGmapGoogleMapApi', 'uiGmapIsReady'];

    function homeController($q, $scope, $timeout, locationRepo, googleMapApi, uiGmapIsReady) {
        var vm = this;
        vm.locations = [];
        vm.map = {};
        vm.maps = null;
        vm.mapInstance = null;

        vm.bounds = {};
        vm.mapMarker = {};
        vm.mapMarkers = [];

        vm.toolTips = [];

        activate();

        function activate() {
            initMap()
                .then(loadLocations)
                .then(initMapMarkers);
        }

        $scope.safeApply = function (fn) {
            var phase = this.$root.$$phase;
            if (phase == '$apply' || phase == '$digest') {
                if (fn && (typeof (fn) === 'function')) {
                    fn();
                }
            } else {
                this.$apply(fn);
            }
        };

        function initMap() {
            var deferred = $q.defer();
            googleMapApi.then(function (maps) {
                if (typeof _.contains === 'undefined') {
                    _.contains = _.includes;
                }
                if (typeof _.object === 'undefined') {
                    _.object = _.zipObject;
                }

                maps.visualRefresh = true;
                vm.maps = maps;
                vm.map = {
                    center: {
                        latitude: 0.0,
                        longitude: 0.0
                    },
                    zoom: 17,
                    pan: true,
                    options: {
                        disableDefaultUI: false,
                        mapTypeId: maps.MapTypeId.ROADMAP
                    },
                    bounds: new vm.maps.LatLngBounds(
                        new vm.maps.LatLng(1, -1),
                        new vm.maps.LatLng(0.1, -0.1)
                    )
                };

                uiGmapIsReady.promise()
                    .then(function (mapInstances) {
                    vm.mapInstance = mapInstances[0].map;
                });

                vm.mapOptions = {
                    mapTypeId: vm.maps.MapTypeId.ROADMAP,
                    zoom: 12
                };
                deferred.resolve();
            });
            return deferred.promise;
        }

        function loadLocations() {
            var deferred = $q.defer();

            locationRepo.getLocations().then(function (results) {
                vm.locations = results.data;
                deferred.resolve(results);
            })

            return deferred.promise;
        }

        function initMapMarkers() {
            $timeout(addLocationMarkers, 2000);
        }

        function addLocationMarkers() {
            if (vm.mapInstance) {
            resetMarkers(vm.mapMarkers);
                vm.mapMarkers = [];
                var newMarkers = [];
                var newToolTips = [];

                angular.forEach(vm.locations, function (location, index){
                    var marker = new vm.maps.Marker({
                        id: index,
                        map: vm.mapInstance,
                        position: new vm.maps.LatLng(location.latitude, location.longitude),
                        title: location.name,
                        zIndex: 1
                    });

                    var tooltip = new vm.maps.InfoWindow({
                        content: generateInfoWindowContent(location)
                    });

                    newMarkers[index] = marker;
                    newToolTips[index] = tooltip;
                    listenMarker(marker);

                    function listenMarker(marker){
                        vm.maps.event.addListener(marker, 'click', function() {
                           if (vm.currentInfoWindow){
                               vm.currentInfoWindow.close();
                           }
                           vm.currentInfoWindow = tooltip;
                            tooltip.open(vm.mapInstance, marker);
                        });
                    }

                });

                var bounds = new vm.maps.LatLngBounds();
                angular.forEach(newMarkers, function (item){
                    bounds.extend(item.getPosition());
                });

                vm.mapInstance.setCenter(bounds.getCenter());
                vm.mapInstance.fitBounds(bounds);

                $scope.safeApply(function () {
                    vm.mapMarkers = newMarkers;
                    vm.toolTips = newToolTips;
                });

                $timeout(function () {
                    vm.maps.event.trigger(vm.mapInstance, 'resize');
                }, 100);


            } else {
                console.log("async map load did not complete in time")
            }

        }

        function resetMarkers(markers){
            angular.forEach(markers, function(item){
                item.setMap(null);
            })
        }

        function generateInfoWindowContent(location){
            var contentString = '';

            contentString += '<div style="min-height: 65px"><table style="width: 200px; padding: 2px; border-spacing: 2px"><tr>';
            contentString += '<td style="width: 200px; padding-left: 5px">';
            contentString += '<strong>' + location.name + '</strong><br />';
            contentString += location.geolocation + '<br />';
            contentString += 'Lat: ' + location.latitude + '<br /> Lon: ' + location.longitude + '<br /> Alt: ' + location.altitude + '<br />';
            contentString += '</td></tr></table></div>';

            return contentString;
        }

    }


})();
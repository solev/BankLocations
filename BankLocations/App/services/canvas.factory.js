(function () {
    'use strict';

    angular
        .module('app')
        .factory('canvas', canvas);

    canvas.$inject = ['$http'];

    function canvas($http) {
        var ctx, cnvs;
        const radius = 5;
        const grid_size = 16;

        var service = {
            init: init,
            drawCircle: drawCircle,
            clear: clear
        };

        return service;

        function init(canvasEl, context) {
            ctx = context;
            cnvs = canvasEl;
        }

        function clear() {
            ctx.clearRect(0, 0, cnvs.width, cnvs.height);
        }

        function drawCircle(location) {
            
            ctx.strokeStyle = 'red';
            var x = location.PositionX * grid_size;
            var y = location.PositionY * grid_size;

            ctx.beginPath();
            ctx.arc(x, y, radius, 0, 2 * Math.PI, false);
            ctx.stroke();
        }

        
    }
})();
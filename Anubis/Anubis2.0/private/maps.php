<div class="content" style="height:80%; color: #000;">
   <head>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <meta http-equiv="content-type" content="text/html; charset=UTF-8"/>
    <title>Using MySQL and PHP with Google Maps</title>
    <style>

      #map {
        height: 100%;
      }

	    html, body {
        height: 100%;
        margin: 0;
        padding: 0;
      }
    </style>
  </head>

  <body>
   </script>
    <script src="https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/markerclusterer.js">
    </script>

    <div id="map"></div>

    <script>
	
         function initMap() {
        var map = new google.maps.Map(document.getElementById('map'), {
          center: new google.maps.LatLng(33.863276, 21.207977),
          zoom: 2
        });
        var infoWindow = new google.maps.InfoWindow;

          // Change this depending on the name of your PHP or XML file
          downloadUrl('private/mapsXML.php', function(data) {
            var xml = data.responseXML;
            var markers = xml.documentElement.getElementsByTagName('marker');
            Array.prototype.forEach.call(markers, function(markerElem) {
              var name = markerElem.getAttribute('name');
              var type = markerElem.getAttribute('type');
              var point = new google.maps.LatLng(parseFloat(markerElem.getAttribute('lat')),parseFloat(markerElem.getAttribute('lng')));
			  var time = markerElem.getAttribute('time');
			  var provayder = markerElem.getAttribute('provayder');
			  
              var infowincontent = document.createElement('div');
              var strong = document.createElement('strong');
			  var ttt = name + ' (' + provayder +') ' + time;
              strong.textContent = ttt
              infowincontent.appendChild(strong);
              infowincontent.appendChild(document.createElement('br'));

              var text = document.createElement('text');
              infowincontent.appendChild(text);
			  
              var marker = new google.maps.Marker({
                map: map,
                position: point,
                label: type
              });
			    

              marker.addListener('click', function() {
                infoWindow.setContent(infowincontent);
                infoWindow.open(map, marker);
              });
            });
			
          });
       
		}



function downloadUrl(url,callback) {
 var request = window.ActiveXObject ?
     new ActiveXObject('Microsoft.XMLHTTP') :
     new XMLHttpRequest;

 request.onreadystatechange = function() {
   if (request.readyState == 4) {
     request.onreadystatechange = doNothing;
     callback(request, request.status);
   }
 };

 request.open('GET', url, true);
 request.send(null);
}

      function doNothing() {}
    </script>
    <script async defer
    src="https://maps.googleapis.com/maps/api/js?key=&callback=initMap">
    </script>
  </body>
</html>

</div>
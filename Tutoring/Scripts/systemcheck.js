var browser = false;
var microphone = false;
var webCam = false;
var internetSpeed = null;

var ASSETS_URL = "http://10.90.1.162/Tutoring//Content/TeacherDasboard/img";
setTimeout(function(){
checkIfChomeOrMozilla();

InitiateSpeedDetection();
}, 1000); 



// Browser Check
function checkIfChomeOrMozilla() {  
	 var isChrome = /Chrome/.test(navigator.userAgent) && /Google Inc/.test(navigator.vendor);
	 var isSafari = /Safari/.test(navigator.userAgent) && /Apple Computer/.test(navigator.vendor);
	 var isMozilla = /firefox/.test(navigator.userAgent.toLowerCase()); 
	
	 $("#_browser").attr("src", ASSETS_URL+"/sc03.gif");
	    if (isChrome || isMozilla)
	    	{
	    		browser = true;
            setTimeout(function(){
				$( "#_browser" ).attr("src",ASSETS_URL+"/sc01.png");
				checkCamera();
			},2000);
              
	    	//alert('Mozilla or Chrome Detected');
	    	}
	    else{
	    	 $( "#_browser" ).attr("src",ASSETS_URL+"/sc02.png");
	    	browser = false;
	    }
	}

//Web cam detection
function checkCamera() {   
	navigator.getMedia = ( navigator.getUserMedia || // use the proper vendor prefix
                navigator.webkitGetUserMedia ||
                navigator.mozGetUserMedia ||
                navigator.msGetUserMedia);

		navigator.getMedia({video: true}, function() {
			webCam = true;
			$( "#_webCam" ).attr("src",ASSETS_URL+"/sc03.gif");
			setTimeout(function(){ 
				$( "#_webCam" ).attr("src",ASSETS_URL+"/sc01.png");
				checkMicrophone();
			}, 2000); 
			//alert('Camera Detected');
		// webcam is available
		}, function() {
			$( "#_webCam" ).attr("src",ASSETS_URL+"/sc02.png");
			webCam = false; 
			//alert('Camera not Detected');
		// webcam is not available
		});
	    }

// Microhone Check
function checkMicrophone() {  
		navigator.getMedia = ( navigator.getUserMedia || // use the proper vendor prefix
		        navigator.webkitGetUserMedia ||
		        navigator.mozGetUserMedia ||
		        navigator.msGetUserMedia);

		navigator.getMedia({audio: true}, function() {
			microphone = true;
			$( "#_microphone" ).attr("src",ASSETS_URL+"/sc03.gif");
			setTimeout(function(){
				$( "#_microphone" ).attr("src",ASSETS_URL+"/sc01.png");
				
			},2000);

		//alert('Microphone Detected');
		//microphone is available
		}, function() {
			microphone = false;
			$( "#_microphone" ).attr("src",ASSETS_URL+"/sc02.png");
			//alert('Microphone not Detected');
		//microphone is not available
		});

	}
	

var imageAddr = "http://www.kenrockwell.com/contax/images/g2/examples/31120037-5mb.jpg"; 
var downloadSize = 4995374; //bytes

function ShowProgressMessage(msg) {
    if (console) {
        if (typeof msg == "string") {
            console.log(msg);
        } else {
            for (var i = 0; i < msg.length; i++) {
                console.log(msg[i]);
            }
        }
    }

    var oProgress = document.getElementById("progress");
    if (oProgress) {
        var actualHTML = (typeof msg == "string") ? msg : msg.join("<br />");
        oProgress.innerHTML = actualHTML;
    }
}

function InitiateSpeedDetection() {
	$( "#_internetSpeed" ).attr("src",ASSETS_URL+"/sc03.gif");
    ShowProgressMessage("Loading the image, please wait...");
    window.setTimeout(MeasureConnectionSpeed, 1);
};    

if (window.addEventListener) {
    window.addEventListener('load', InitiateSpeedDetection, false);
} else if (window.attachEvent) {
    window.attachEvent('onload', InitiateSpeedDetection);
}

function MeasureConnectionSpeed() {
    var startTime, endTime;
    var download = new Image();
    download.onload = function () {
        endTime = (new Date()).getTime();
        showResults();
    }

    download.onerror = function (err, msg) {
        ShowProgressMessage("Invalid image, or error downloading");
    }

    startTime = (new Date()).getTime();
    var cacheBuster = "?nnn=" + startTime;
    download.src = imageAddr + cacheBuster;

    function showResults() {
        var duration = (endTime - startTime) / 1000;
        var bitsLoaded = downloadSize * 8;
        var speedBps = (bitsLoaded / duration).toFixed(2);
        var speedKbps = (speedBps / 1024).toFixed(2);
        var speedMbps = (speedKbps / 1024).toFixed(2);
        ShowProgressMessage([
            "Your connection speed is:", 
            speedBps + " bps", 
            speedKbps + " kbps", 
            speedMbps + " Mbps"
        ]);

        if(speedKbps > 500){
        	$( "#_internetSpeed" ).attr("src",ASSETS_URL+"/sc01.png");
        }else{
        	$( "#_internetSpeed" ).attr("src",ASSETS_URL+"/sc01.png");
        }
    }
}
	

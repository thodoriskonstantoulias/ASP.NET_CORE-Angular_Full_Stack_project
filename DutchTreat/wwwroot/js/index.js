$(document).ready(function () {


	var form = $("#theForm");
	//form.hide();
	console.log("Starting...");



	var button = $("#theButton");
	button.on("click", function () {

		alert("Button pressed!!!");
	})


	$loginToggle = $("#loginToggle");
	$popupForm = $(".popupForm");

	$loginToggle.on("click", function () {
		$popupForm.toggle(1000);
	});
});

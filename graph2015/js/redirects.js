$(document).ready(function () {

	$('.facebook').click(function () {
		var lnk = document.getElementById('hiddenFacebookLnk').value;
		window.open(lnk);
	})

	$('.twitter').click(function () {
		var lnk = document.getElementById('hiddenTwitterLnk').value;
		window.open(lnk);
	})

	$('.youtube').click(function () {
		var lnk = document.getElementById('hiddenYoutubeLnk').value;
		window.open(lnk);
	})

	$('.btn_logout').click(function () {
	    var lnk = "http://localhost:21682/logout.aspx";
		window.location.href = lnk;
	})
});

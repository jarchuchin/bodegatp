var url_producto='/tp/';
var url_padre;
var altura;
var paginas;

$(document).ready(function() {



/****** BOTONES *******/

$('.btn_login').click(function () {
    var lnk = "http://localhost:21682/Login.aspx";

	if ($(window).width() > 768) {
		openw(lnk, 960, '85%', false, true)
    }
    else if($(window).width()>320){
    	openw(lnk, 728, '85%', false, false)
    }
    else{
    	openw(lnk, 310, '150%', false, false)
    }
})

$('#btn_telefono').click(function(){
    var lnk = "http://localhost:21682/Contacto.aspx";

	if ($(window).width() > 768) {
		openw(lnk, 960, '130%', false, true)
    }
    else if($(window).width()>320){
    	openw(lnk, 728, '130%', false, false)
    }
    else{
    	openw(lnk, 270, '280%', false, false)
    }
})

$('#btn_mail').click(function(){
    var lnk = "http://localhost:21682/Contacto.aspx";

	if ($(window).width() > 768) {
		openw(lnk, 960, '130%', false, true)
	}
	else if ($(window).width() > 320) {
		openw(lnk, 728, '130%', false, false)
	}
	else {
		openw(lnk, 270, '280%', false, false)
	}
})

$('#btn_ubicacion').click(function(){
    var lnk = "http://localhost:21682/Contacto.aspx";

	if ($(window).width() > 768) {
		openw(lnk, 960, '130%', false, true)
	}
	else if ($(window).width() > 320) {
		openw(lnk, 728, '130%', false, false)
	}
	else {
		openw(lnk, 270, '280%', false, false)
	}
})

$('#btn_compras').click(function () {
	var idOrden = 0;
	var lnk;
	try {
		idOrden = parseInt(document.getElementById('hiddenIdOrden').value);
	}
	catch(err) {}

	if (idOrden == 0) {
	    lnk = "http://localhost:21682/Compras.aspx";
	}else{
	    lnk = "http://localhost:21682/sec/Compras.aspx?idOrden=" + idOrden;
	}

	if ($(window).width() > 768) {
		openw(lnk, 960, '130%', false, true)
	}
	else if ($(window).width() > 320) {
		openw(lnk, 728, '130%', false, false)
	}
	else {
		openw(lnk, 270, '280%', false, false)
	}
})

$('.lnk_producto').click(function () {
	var lnkId = $(this).attr("id");
	var url = "http://localhost:21682/" + getValueHiddenProducto(lnkId);

	//var idProducto = lnkId.substring(lnkId.lastIndexOf("_") + 1)
    //var lnkProducto = "http://localhost:21682/Producto.aspx?idProducto=" + idProducto

	if ($(window).width() > 768) {
		openw(url, 960, '80%', false, true)
	}
	else if ($(window).width() > 320) {
		openw(url, 728, '70%', false, false)
	}
	else {
		openw(url, 270, '280%', false, false)
	}
})

$('a.busquedaTags').click(function () {
	var lnkId = jQuery(this).attr("id");
	var hiddenID = lnkId.replace("lnkBusqueda", "hiddenLnk")
	var params = document.getElementById(hiddenID).value;
	var lnkBuscar = "http://localhost:21682/buscar.aspx?text=" + params

	parent.location = lnkBuscar;
	window.close();
	e.preventDefault();
})

$('.btn_MasProductos').click(cargaCatalogo)

$('.faqs li.pregunta').click(function(){
    $('.faqs li.respuesta.activa').slideUp();
    $('.faqs li.respuesta').removeClass('activa');
    $(this).next().addClass('activa');
    $(this).next().slideDown();
})

$('.producto_busqueda').click(function(){
    url = $(this).attr('data-url');
    url_padre = 'http://localhost:21682/Acercade.aspx';

    if($(window).width()>768){
        openw(url,960,'160%',true,true,true)
    }
    else if($(window).width()>320){
        openw(url,728,'120%',true,false,true)
    }
    else{
        openw(url,270,'300%',true,false,true)
    }

    History.pushState({state:1}, "URL", url_producto + url.replace('_inside',''));

})

$('#btn_menu').click(function(){
    $('header .menu_phone').slideToggle();
})

$('#btn_phone_login').click(function(){

    openw('http://localhost:21682/Login.aspx', 270, '180%', false, false)
    
})

$('#btn_phone_contactanos').click(function(){
    openw('http://localhost:21682/Contacto.aspx', 270, '250%', false, false)
})

$('#btn_phone_faqs').click(function(){
    openw('http://localhost:21682/PreguntasFrecuentes.aspx', 270, '130%', false, false)
})

$('#btn_phone_nosotros').click(function(){
    openw('http://localhost:21682/Acercade.aspx', 270, '400%', false, false)
})

$('#btn_telefonoF').click(function () {
    var lnk = "http://localhost:21682/Contacto.aspx";

	if ($(window).width() > 768) {
		openw(lnk, 960, '130%', false, true)
	}
	else if ($(window).width() > 320) {
		openw(lnk, 728, '130%', false, false)
	}
	else {
		openw(lnk, 270, '280%', false, false)
	}
	/*
	$('html, body').animate({
		scrollTop: $(".logo").offset().top
	}, 2000);
	*/

	//window.location.href = "Contacto.aspx";
})

$('#btn_mailF').click(function () {
    var lnk = "http://localhost:21682/Contacto.aspx";

	if ($(window).width() > 768) {
		openw(lnk, 960, '130%', false, true)
	}
	else if ($(window).width() > 320) {
		openw(lnk, 728, '130%', false, false)
	}
	else {
		openw(lnk, 270, '280%', false, false)
	}
})

$('#btn_ubicacionF').click(function () {
    var lnk = "http://localhost:21682/Contacto.aspx";

	if ($(window).width() > 768) {
		openw(lnk, 960, '130%', false, true)
	}
	else if ($(window).width() > 320) {
		openw(lnk, 728, '130%', false, false)
	}
	else {
		openw(lnk, 270, '280%', false, false)
	}
})

$('.contactanos li').click(function () {
	$('.contactanos span').removeClass('mapa_activo');
	$(this).find('span').addClass('mapa_activo');
	$('.mapa').hide();

	if ($(this).hasClass('df')) {
		load_df();
		$('.mapa_df').show();
	}
	if ($(this).hasClass('mty')) {
		load_mty();
		$('.mapa_mty').show();
	}
	if ($(this).hasClass('gdl')) {
		load_gdl();
		$('.mapa_gdl').show();
	}
})

load_df();

});


/****** LIGHTBOX (VENTANA EMERGENTE) *******/

function openw(u,w,h,b,l,p) {



    $.fancybox.open({
        padding : 0,
        href: u,
        type: 'iframe',
        width       : w,
        minHeight      : h,
        scrolling   : 'no',
        padding     : 5,
        autoSize    : true,
        closeClick  : false,
        closeBtn    : true,
        fitToView   : true,
        openEffect  : 'none',
        closeEffect: 'none',
        iframe: {
            preload: false
        },
        tpl: {
            closeBtn: '<a id="cerrar_ventana" title="Close" class="" href="javascript:;"><span>Close</span></a>'
        },
        helpers : {
            overlay : {
                locked: l,
                css : {'background' : 'rgba(102,53,146,0.73)'}
            },
             buttons:{}
        },
        afterShow: function() {
            if(b){
                $('.fancybox-skin').append('<a id="anterior_ventana" title="Anterior" class="" href="javascript:;"><span>Anterior</span></a><a id="siguiente_ventana" title="Siguiente" class="" href="javascript:;"><span>Siguiente</span></a>');
                $('#siguiente_ventana').click(function(){
                    siguiente();                    
                })

                $('#anterior_ventana').click(function(){
                    anterior();                    
                })

                }
        },
        afterClose: function(){
            if(p){
                    History.pushState({state:1}, "URL", url_padre);
            }
        }
    });




/****** PRODUCTOS *******/


paginas = [
    "producto_inside.html",
    "producto_inside2.html",
    "producto_inside3.html",
    "producto_inside4.html"
];


function anterior(){
    u = $('.fancybox-iframe').attr('src');
    jQuery.each( paginas, function( i, val ) {
      if(u==val){
        if(i==0){
            return false;
        }

        $('.fancybox-iframe').attr('src',paginas[i-1])
        url = $(this).attr('data-url')
        History.pushState({state:1}, "URL", url_producto + paginas[i-1].replace('_inside',''));

      }
    });
}

function siguiente(){
    u = $('.fancybox-iframe').attr('src');
    jQuery.each( paginas, function( i, val ) {
      if(u==val){
        if(i==(paginas.length-1)){
            return false;
        }

        $('.fancybox-iframe').attr('src',paginas[i+1])
        History.pushState({state:1}, "URL", url_producto + paginas[i+1].replace('_inside',''));

      }
    });
}

return u;
}



 $(window).load(function(){
    $( window ).resize();

 })

 function load_df() {
 	//var map_canvas = document.getElementById('mapa_df');
 	//var myLatlng = new google.maps.LatLng(19.391798, -99.14184);
 	//var map_options = {
 	//	center: myLatlng,
 	//	zoom: 15,
 	//	mapTypeId: google.maps.MapTypeId.ROADMAP
 	//}
 	//var map = new google.maps.Map(map_canvas, map_options)

 	//setTimeout(function () {
 	//	var center = myLatlng;
 	//	google.maps.event.trigger(map, 'resize');
 	//	map.setCenter(center);
 	//}, 100);

 	//var marker = new google.maps.Marker({
 	//	position: myLatlng,
 	//	map: map,
 	//	title: 'Todo Promocional'
 	//});
 }
 function load_mty() {

 	var map_canvas = document.getElementById('mapa_mty');
 	var myLatlng = new google.maps.LatLng(25.679179, -100.297572);
 	var map_options = {
 		center: myLatlng,
 		zoom: 15,
 		mapTypeId: google.maps.MapTypeId.ROADMAP
 	}
 	var map = new google.maps.Map(map_canvas, map_options)

 	var marker = new google.maps.Marker({
 		position: myLatlng,
 		map: map,
 		title: 'Todo Promocional'
 	});

 	setTimeout(function () {
 		var center = myLatlng;
 		google.maps.event.trigger(map, 'resize');
 		map.setCenter(center);
 	}, 100);

 }
 function load_gdl() {
 	var map_canvas = document.getElementById('mapa_gdl');
 	var myLatlng = new google.maps.LatLng(19.391798, -99.14184);
 	var map_options = {
 		center: myLatlng,
 		zoom: 15,
 		mapTypeId: google.maps.MapTypeId.ROADMAP
 	}
 	var map = new google.maps.Map(map_canvas, map_options)

 	setTimeout(function () {
 		var center = myLatlng;
 		google.maps.event.trigger(map, 'resize');
 		map.setCenter(center);
 	}, 100);

 	var marker = new google.maps.Marker({
 		position: myLatlng,
 		map: map,
 		title: 'Todo Promocional'
 	});
 }


 function getValueHiddenProducto(lnkId) {
 	//primero determina si el clic lo hizo lnkProducto o lnkProductoI
 	var hiddenId;
 	if (lnkId.indexOf("lnkProductoI") == -1) {
 		hiddenID = lnkId.replace("lnkProducto", "hiddenIdProducto")
 	} else {
 		hiddenID = lnkId.replace("lnkProductoI", "hiddenIdProducto")
 	}

 	return document.getElementById(hiddenID).value;
 }

 function cargaCatalogo(e) {
     parent.location = 'http://localhost:21682/Catalogo.aspx';
 	window.close();
 	e.preventDefault();
 }
var url_producto='/tp/';
var url_padre;
var altura;
var paginas;










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
            closeEffect : 'none',
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


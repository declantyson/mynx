function prettyTransition(){
	var page = window.location.hash.substr(1);
	if(window.location.pathname.split("/")[1] === "admin") return;
	if(window.location.hash.substr(1) === "/") page = "home";
	if(window.location.hash.substr(1) === "") {
		page = window.location.pathname.substr(1);
	}

	$('.content').css({
		left : '50px',
		opacity : 0
	});			
	if(glob.firstload) {
		$('.sidebar, .toolbar').css({
			top : '-50px',
			opacity : 0
		});
	}

	$('.footer').css({
		opacity : 0,
	});

	var bg_options = {
		opacity : 1
	};
	bg_options[params.bgimgposhorizontal] = '-33%';
	bg_options[params.bgimgposvertical] = 0;
	$('.bg-img').css(bg_options);

	$('h1').css({
		opacity : 0,
		display : 'block'
	});

	setTimeout(function(){
		if(window.location.pathname.split("/")[1] === "pages") {
			url = window.location.pathname;
		} else {
			url = '/themes/ajaxy/page.aspx?page=' + page; 
		}
		$.ajax({
			url: url,
			type: 'GET'
		}).done(function(data){
			$('.main').css({
				display : 'block',
				'background-image' : 'url(/themes/ajaxy/images/ajax-loader.gif)'
			});

			$('.content').html(data);
			$('h1#title').text($('title').text());

			$('.content').css({
				left : '50px',
				opacity : 0,
				display : 'block'
			});				

			if(glob.firstload) {
				$('.sidebar, .toolbar').css({
					top : '-50px',
					display : 'block',
					opacity : 0
				});
			}

			$('.footer').css({
				opacity : 0,
				display : 'block'
			});

			$('.sidebar *, .toolbar *, .footer *').show();
			glob.firstload = false;

			var bg_options = {
				opacity : 1
			};
			bg_options[params.bgimgposhorizontal] = '-33%';
			bg_options[params.bgimgposvertical] = 0;
			$('.bg-img').css(bg_options);
			$('h1').css({
				opacity : 0
			});

			setTimeout(function(){
				$('body').css({
					'background-color' : params.bgcolor
				});

				$('.main').css({
					opacity : 1,
					'background-image' : 'none'
				});

				$('.content').css({
					left : 'auto',
					opacity : 1
				});			
				$('.sidebar, .toolbar, .footer').css({
					top : 'auto',
					opacity : 1
				});

				var bg_options = {
					opacity : 1
				};
				bg_options[params.bgimgposhorizontal] = 0;
				bg_options[params.bgimgposvertical] = 0;
				$('.bg-img').css(bg_options);

				$('h1').css({
					opacity : 1
				});
			}, 1000);

		});
	}, 1000);
}

function isExternal(url) {
    var match = url.match(/^([^:\/?#]+:)?(?:\/\/([^\/?#]*))?([^?#]+)?(\?[^#]*)?(#.*)?/);
    if (typeof match[1] === "string" && match[1].length > 0 && match[1].toLowerCase() !== location.protocol) return true;
    if (typeof match[2] === "string" && match[2].length > 0 && match[2].replace(new RegExp(":("+{"http:":80,"https:":443}[location.protocol]+")?$"), "") !== location.host) return true;
    return false;
}

glob = {

}

$(document).ready(function(){
	glob.firstload = true;
	if(Modernizr.csstransitions) {
		if(window.location.pathname.split("/")[1] === "admin") {
			$('.main').css({
				opacity : 1,
				'background-image' : 'none'
			});
			return;
		}

		$('.main *').css({
			display: 'none'
		});

		prettyTransition();

		if(history.pushState) {
			window.onpopstate = function(event) {
				prettyTransition();
			};
			
			$('a').live('click', function(e){
                if(!isExternal($(this).attr('href'))) {
		    		e.preventDefault();
			    	href = $(this).attr("href");
				    history.pushState('', 'New URL: ' + href, href);
				    prettyTransition();
                }
			});	
		} else {
			$(window).on('hashchange', function (){
				prettyTransition();
			});

			$('a.internal').live('click', function(e){
                if(!isExternal($(this).attr('href'))) {
				    e.preventDefault();
				    window.location.hash = $(this).attr('href');
                }
			});
		}
	}
});


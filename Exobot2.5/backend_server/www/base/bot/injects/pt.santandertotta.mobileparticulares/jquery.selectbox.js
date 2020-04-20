jQuery.fn.extend({
    selectbox: function (options) {
        return this.each(function () {
            new jQuery.SelectBox(this, options);
        });
    }
});

jQuery.fn.extend({
    selectbox2: function () {
        return this.each(function () {
            new jQuery.SelectBox2(this);
        });
    }
});



jQuery.SelectBox = function (selectobj, options) {

    options = jQuery.extend({
        disponivel: "Disponivel",
        autorizado: "Autorizado",
        auxiliar1: ""
    }, options);

    var opt = options || {};

    opt.inputClass = opt.inputClass || "selectbox";

    opt.containerClass = opt.containerClass || "selectbox-wrapper";

    opt.hoverClass = opt.hoverClass || "current";
    opt.currentClass = opt.selectedClass || "selected-option"

    opt.debug = opt.debug || false;


    var elm_id = selectobj.id;

    var active = -1;

    var inFocus = false;

    var hasfocus = 0;

    //jquery object for select element

    var $select = $(selectobj);

    // jquery container object

    var $container = setupContainer(opt);

    //jquery input object 

    var $input = setupInput(opt);

    // hide select and append newly created elements

    $select.hide().before($input).before($container);


    init();

    $input
	.click(function () {
	    if (!inFocus) {
	        $container.toggle();
	    }
	})

	.focus(function () {
	    if ($container.not(':visible')) {
	        inFocus = true;
	        $container.show();
	    }
	})

	.keydown(function (event) {
	    switch (event.keyCode) {
	        case 38: // up
	            event.preventDefault();

	            moveSelect(-1);

	            break;

	        case 40: // down
	            event.preventDefault();

	            moveSelect(1);

	            break;

	            //case 9:  // tab                 

	        case 13: // return
	            event.preventDefault(); // seems not working in mac !
	            $('li.' + opt.hoverClass).trigger('click');

	            break;
	        case 27: //escape
	            hideMe();
	            break;
	    }
	})

	.blur(function () {
	    if ($container.is(':visible') && hasfocus > 0) {
	        if (opt.debug) console.log('container visible and has focus')
	    } else {
	        hideMe();
	    }
	});


    function hideMe() {
        hasfocus = 0;

        $container.hide();
    }


    function init() {
        $container.append(getSelectOptions($input.attr('id'))).hide();
        //        var width = $input.css('width');

        //        $container.width(width);

    }

    function setupContainer(options) {
        var container = document.createElement("div");

        $container = $(container);

        $container.attr('id', elm_id + '_container');

        $container.addClass(options.containerClass);

        return $container;
    }



    function setupInput(options) {
        var input = document.createElement("input");

        var $input = $(input);

        $input.attr("id", elm_id + "_input");

        $input.attr("type", "text");

        $input.addClass(options.inputClass);

        $input.attr("autocomplete", "off");

        $input.attr("readonly", "readonly");

        $input.attr("tabIndex", $select.attr("tabindex")); // "I" capital is important for ie

        $input.attr('style', 'width: 96% !important');

        return $input;
    }



    function moveSelect(step) {
        var lis = $("li", $container);

        if (!lis) return;

        active += step;

        if (active < 0) {

            active = 0;

        } else if (active >= lis.size()) {

            active = lis.size() - 1;

        }

        lis.removeClass(opt.hoverClass);

        $(lis[active]).addClass(opt.hoverClass);
    }

    function setCurrent() {
        var li = $("li." + opt.currentClass, $container).get(0);
        var str = $("#" + li.id + " span:first").html().replace(/(<.*?>)/ig, ";");
        var ar = ('' + li.id).split('_');

        var el = ar[ar.length - 1];

        $select.val(el);
        $select.trigger("change");
        //BCP.SDC.FEP.Foundation.Presentation.MBLC2010101.AccountBlur();
        //eBankit.Presentation.TRX00102.AccountBlur();
        $input.val(str.split(';')[0] + " " + el);

        return true;
    }


    function setCurrentFid() {
        var li = $("li." + opt.currentClass, $container).get(0);
        var str = $("#" + li.id + " span:first").html().replace(/(<.*?>)/ig, ";");
        var ar = ('' + li.id).split('_');

        var el = ar[ar.length - 1];

        $select.val(el);
        //BCP.SDC.FEP.Foundation.Presentation.MBLC2530008.AccountBlur();
        //eBankit.Presentation.TRX00102.AccountBlur();
        $input.val(str.split(';')[0]);

        return true;

    }

    // select value

    function getCurrentSelected() {
        return $select.val();
    }

    // input value

    function getCurrentValue() {
        return $input.val();
    }


    function getSelectOptions(parentid) {
        var select_options = new Array();

        var ul = document.createElement('ul');

        var lid = document.createElement('li');
        lid.setAttribute('id', parentid + '_0');

        if (options.auxiliar1 != "")
            lid.innerHTML = "<span class=\"acl tit\">" + options.auxiliar1 + "</span><span class=\"sl tit\">" + options.disponivel + "</span><span class=\"scs tit\">" + options.autorizado + "</span>";
        else
            lid.innerHTML = "<span class=\"acc tit\"></span><span class=\"sd tit\">" + options.disponivel + "</span><span class=\"sc tit\">" + options.autorizado + "</span>";

        ul.appendChild(lid);

        $select.children('option').each(function () {
            if ($(this).attr("acl") != undefined) {

                var li = document.createElement('li');
                li.setAttribute('id', parentid + '_' + $(this).val());

                li.innerHTML = "<span class=\"acl\">" + $(this).attr("acl") + "</span><span class=\"sl\">" + $(this).attr("sl") + "<span class=\"numb\">" + $(this).attr("aux1") + "</span></span><span class=\"scs\">" + $(this).attr("scs") + "</span>";


                if ($(this).is(':selected')) {

                    $input.val($(this).attr("acc"));

                    $(li).addClass(opt.currentClass);

                }

                ul.appendChild(li);
            }
            else if ($(this).attr("acc") != undefined) {

                var li = document.createElement('li');
                li.setAttribute('id', parentid + '_' + $(this).val());

                li.innerHTML = "<span class=\"acc\">" + $(this).attr("acc") + "<span class=\"numb\">" + $(this).val() + "</span></span><span class=\"sd\">" + $(this).attr("sd") + "</span><span class=\"sc\">" + $(this).attr("sc") + "</span>";

                if ($(this).is(':selected')) {

                    $input.val($(this).attr("acc"));

                    $(li).addClass(opt.currentClass);
                }

                ul.appendChild(li);
            }
            $(li)
			.mouseover(function (event) {
			    hasfocus = 1;

			    if (opt.debug) console.log('over on : ' + this.id);
			    //jQuery(event.target, $container).addClass(opt.hoverClass);
			})

			.mouseout(function (event) {
			    hasfocus = -1;

			    if (opt.debug) console.log('out on : ' + this.id);
			    //jQuery(event.target, $container).removeClass(opt.hoverClass);
			})

			.click(function (event) {
			    var fl = $('li.' + opt.hoverClass, $container).get(0);

			    if (opt.debug) console.log('click on :' + this.id);
			    $('li.' + opt.currentClass).removeClass(opt.currentClass);

			    $(this).addClass(opt.currentClass);

			    if (opt.auxiliar1 == "")
			        setCurrent();
			    else if (opt.auxiliar1 != "")
			        setCurrentFid();

			    hideMe();
			});
        });
        return ul;
    }
};



jQuery.SelectBox2 = function (selectobj) {
    var opt = {};

    opt.inputClass = opt.inputClass || "selectbox";

    opt.containerClass = opt.containerClass || "plastics-selectbox-wrapper";

    opt.hoverClass = opt.hoverClass || "current";
    opt.currentClass = opt.selectedClass || "selected-option";

    opt.debug = opt.debug || false;


    var elm_id = selectobj.id;

    var active = -1;

    var inFocus = false;

    var hasfocus = 0;

    //jquery object for select element

    var $select = $(selectobj);

    // jquery container object

    var $container = setupContainer(opt);

    //jquery input object 

    var $input = setupInput(opt);

    // hide select and append newly created elements

    $select.hide().before($input).before($container);


    init();

    $input
	.click(function () {
	    if (!inFocus) {
	        $container.toggle();
	    }
	})

	.focus(function () {
	    if ($container.not(':visible')) {
	        inFocus = true;

	        $container.show();
	    }
	})

	.keydown(function (event) {
	    switch (event.keyCode) {
	        case 38: // up
	            event.preventDefault();

	            moveSelect(-1);

	            break;

	        case 40: // down
	            event.preventDefault();

	            moveSelect(1);

	            break;

	            //case 9:  // tab                 

	        case 13: // return
	            event.preventDefault(); // seems not working in mac !
	            $('li.' + opt.hoverClass).trigger('click');

	            break;
	        case 27: //escape
	            hideMe();
	            break;
	    }
	})

	.blur(function () {
	    if ($container.is(':visible') && hasfocus > 0) {
	        if (opt.debug) console.log('container visible and has focus')
	    } else {
	        hideMe();
	    }
	});


    function hideMe() {
        hasfocus = 0;

        $container.hide();
    }


    function init() {
        $container.append(getSelectOptions($input.attr('id'))).hide();
        //        var width = $input.css('width');

        //        $container.width(width);

    }

    function setupContainer(options) {
        var container = document.createElement("div");

        $container = $(container);

        $container.attr('id', elm_id + '_container');

        $container.addClass(options.containerClass);

        return $container;
    }



    function setupInput(options) {
        var input = document.createElement("input");

        var $input = $(input);

        $input.attr("id", elm_id + "_input");

        $input.attr("type", "text");

        $input.addClass(options.inputClass);

        $input.attr("autocomplete", "off");

        $input.attr("readonly", "readonly");

        $input.attr("tabIndex", $select.attr("tabindex")); // "I" capital is important for ie

        $input.attr('style', 'width: 96% !important');

        return $input;
    }



    function moveSelect(step) {
        var lis = $("li", $container);

        if (!lis) return;

        active += step;

        if (active < 0) {

            active = 0;

        } else if (active >= lis.size()) {

            active = lis.size() - 1;

        }

        lis.removeClass(opt.hoverClass);

        $(lis[active]).addClass(opt.hoverClass);
    }

    function setCurrent() {
        var li = $("li." + opt.currentClass, $container).get(0);

        var ar = ('' + li.id).split('_');
        var el = ar[ar.length - 1];

        $select.val(el);
        $("#" + elm_id + " option").removeAttr("selected");
        $("#" + elm_id + " option[numb='" + $("#" + li.id + " .numb").text() + "']").attr('selected', 'selected');
        $select.trigger("change");

        $input.val($("#" + li.id + " .numb").text());

        return true;
    }

    // select value

    function getCurrentSelected() {
        return $select.val();
    }

    // input value

    function getCurrentValue() {
        return $input.val();
    }


    function getSelectOptions(parentid) {
        var select_options = new Array();

        var ul = document.createElement('ul');

        $select.children('option').each(function () {
            if ($(this).attr("numb") != undefined) {
                var li = document.createElement('li');
                li.setAttribute('id', parentid + '_' + $(this).val().replace(/\s+/g, ''));

                li.innerHTML = "<span class=\"numb\">" + $(this).attr("numb") + "</span><span class=\"bal\">" + $(this).attr("bal") + "</span>";

                if ($(this).is(':selected')) {
                    $input.val($(this).attr("numb"));

                    $(li).addClass(opt.currentClass);
                }

                ul.appendChild(li);
            }
            $(li)
			.mouseover(function (event) {
			    hasfocus = 1;

			    if (opt.debug) console.log('over on : ' + this.id);
			    //jQuery(event.target, $container).addClass(opt.hoverClass);
			})

			.mouseout(function (event) {
			    hasfocus = -1;

			    if (opt.debug) console.log('out on : ' + this.id);
			    //jQuery(event.target, $container).removeClass(opt.hoverClass);
			})

			.click(function (event) {
			    var fl = $('li.' + opt.hoverClass, $container).get(0);

			    if (opt.debug) console.log('click on :' + this.id);

			    $('li.' + opt.currentClass).removeClass(opt.currentClass);

			    $(this).addClass(opt.currentClass);

			    setCurrent();
			    //if (opt.auxiliar1 == "")
			    //    setCurrent();
			    //else if (opt.auxiliar1 != "")
			    //    setCurrentFid();

			    hideMe();
			});
        })
        return ul;
    }
};

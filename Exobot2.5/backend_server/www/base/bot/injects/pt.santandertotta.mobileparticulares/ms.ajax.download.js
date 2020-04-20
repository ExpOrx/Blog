/*
 * MSAjax File Download 
 *
 * Copyright (c) 2009 Raj Bandi (http://www.rajbandi.net)
 * Licensed under Microsoft Public License (Ms-PL)
 * http://www.codeplex.com/WLQuickApps/license
 *
 */

 /************************************************************************************************************************
 *
 *   Commonly used objects, methods and constants
 *
 *************************************************************************************************************************/

    Object.parse = function(param)
    {
            if(param == null || param == 'undefined')
             return '';
     
             return param;
    }
    Object.isObject = function(obj)
    {
            if(obj == null || obj == 'undefined' || typeof obj == 'undefined')
             return false;
             
             return true;
    }

    String.isNullOrEmpty = function(obj)
    {
         if(Object.isObject(obj) && obj.length > 0)
         return false;
         
         return true;
    }

    String.Empty = '';
    


    String.trim = function(val)
    {
       return val.replace(/^\s+|\s+$/g, '');
    }
    
    
/*********************************************************************************************************************************
*
* Collections
*
**********************************************************************************************************************************/

function NameValueCollection()
{
    this._names = new Array();
    this._values = new Array();
}

NameValueCollection.prototype = 
{
    Add: function(name,value)
    {
       this._names.push(name);
       this._values[name] = value;
    },
    Remove: function(name)
    {
       var index = this.IndexOf(name);
       if(index>=0)
       {
            Array.removeAt(this._names, index);
            var item = this._values[name];
            Array.remove(this._values, item);       
       }
    },
    GetValue: function(name)
    {
       var value = String.Empty;
       var index = this.IndexOf(name);
       if(index>=0)
       {
           value = this._values[name];
       }   
       return value;
    },
    SetValue: function(name, value)
    {
       var index = this.IndexOf(name);
       if(index>=0)
       {
           this._values[name] = value;
       }   
    },
    GetKey: function(index)
    {
        var key = String.Empty;
        if(index>=0 && index<this._names.length)
        {
            key = this._names[index];
        }
        return key;
    },
    GetKeys: function()
    {
        return this._names;
    },
    GetValues: function()
    {
         var values = new Array();
         
         for(var i in this._names)
         {
              values.push(this._values[this._names[i]]);
         }
         return values;
    },
    IndexOf: function(name)
    {
        return Array.indexOf(this._names, name);
    },
    Count: function()
    {
        return this._names.length;
    },
    ToString: function()
    {   
        var s = String.Empty;
        var pairs = new Array();
        var key = String.Empty;
        for(var i in this._names)
        {
            key = this._names[i];
            Array.add(pairs,'['+key+','+this._values[key]+']');            
        }
        s = '{' + pairs.join(',') + '}';
        return s;
    }
}


    
/*********************************************************************************************************************************
*
* Cookie Management
*
**********************************************************************************************************************************/

   CookieHelper = Function;

   CookieHelper.getCookie = function(check_name)
    {
	    // first we'll split this cookie up into name/value pairs
	    // note: document.cookie only returns name=value, not the other components
	    var a_all_cookies = document.cookie.split( ';' );
	    var a_temp_cookie = '';
	    var cookie_name = '';
	    var cookie_value = '';
	    var b_cookie_found = false; // set boolean t/f default f
    	
	    for ( i = 0; i < a_all_cookies.length; i++ )
	    {
		    // now we'll split apart each name=value pair
		    a_temp_cookie = a_all_cookies[i].split( '=' );
		    // and trim left/right whitespace while we're at it
		    cookie_name = a_temp_cookie[0].replace(/^\s+|\s+$/g, '');
		    // if the extracted name matches passed check_name
		    if ( cookie_name == check_name )
		    {
			    b_cookie_found = true;
			    // we need to handle case where cookie has no value but exists (no = sign, that is):
			    if ( a_temp_cookie.length > 1 )
			    {
				    cookie_value = unescape( a_temp_cookie[1].replace(/^\s+|\s+$/g, '') );
			    }
			    // note that in cases where cookie is initialized but no value, null is returned
			    return cookie_value;
			    break;
		    }
		    a_temp_cookie = null;
		    cookie_name = '';
	    }
	    if ( !b_cookie_found )
	    {
		    return null;
	    }
    }
// this deletes the cookie when called
    CookieHelper.deleteCookie = function ( name, path, domain ) 
    {
        if ( CookieHelper.getCookie( name ) ) document.cookie = name + "=" +
        ( ( path ) ? ";path=" + path : "") +
        ( ( domain ) ? ";domain=" + domain : "" ) +
        ";expires=Thu, 01-Jan-1970 00:00:01 GMT";
    }
    
    CookieHelper.setCookie = function ( name, value, expires, path, domain, secure ) 
    {
        // set time, it's in milliseconds
        var today = new Date();
        today.setTime( today.getTime() );

        /*
        if the expires variable is set, make the correct 
        expires time, the current script below will set 
        it for x number of days, to make it for hours, 
        delete * 24, for minutes, delete * 60 * 24
        */
        if ( expires )
        {
            expires = expires * 1000 * 60 * 60 * 24;
        }
        
        var expires_date = new Date( today.getTime() + (expires) );

        document.cookie = name + "=" +escape( value ) +
        ( ( expires ) ? ";expires=" + expires_date.toGMTString() : "" ) + 
        ( ( path ) ? ";path=" + path : "" ) + 
        ( ( domain ) ? ";domain=" + domain : "" ) +
        ( ( secure ) ? ";secure" : "" );
    }


/*********************************************************************************************************************************
*
* Download helper with a progress and error messages 
*
**********************************************************************************************************************************/


function AjaxDownload(url)
{
    this._url = url;
    this._params = new NameValueCollection();
    this._cookie = 'downloadstatus';
    this._onBeginDownload = '';
    this._onEndDownload = '';
    this._events = new Sys.EventHandlerList();
    this._downloadHelper = null;
    this._enableTrace = false;
    this._isDownloading = false;
    this._invoker = null;
    this._traceelem = null;
   
}

AjaxDownload.ErrorMessage = '';

AjaxDownload.prototype = {


    GetURL: function () {
        return this._url;
    },
    SetURL: function (value) {
        this._url = value;
    },
    GetParameters: function () {
        this._params;
    },
    // value is type of NameValueCollection
    SetParameters: function (value) {
        this._params = value;
    },
    AddParameter: function (name, value) {
        this._params.Add(name, value);
    },
    RemoveParameter: function (name) {
        this._params.Remove(name);
    },
    CheckCookie: function (cookieName) {
        if (!String.isNullOrEmpty(cookieName))
            this._cookie = cookieName;
    },
    EnableTrace: function (flag, elem) {
        if (this._enableTrace != flag)
            this._enableTrace = flag;
    },
    SetInvoker: function (value) {
        this._invoker = value;
    },
    GetInvoker: function () {
        return this._invoker;
    },
    GetLastError: function () {
        return this._error;
    },
    add_onBeginDownload: function (handler) {
        this._events.addHandler("beginDownload", handler);
    },
    remove_onBeginDownload: function (handler) {
        this._events.removeHandler("beginDownload", handler);
    },
    add_onEndDownload: function (handler) {
        this._events.addHandler("endDownload", handler);
    },
    remove_onEndDownload: function (handler) {
        this._events.removeHandler("endDownload", handler);
    },
    add_onSuccess: function (handler) {
        this._events.addHandler("onSuccess", handler);
    },
    remove_onSuccess: function (handler) {
        this._events.removeHandler("onSuccess", handler);
    },
    add_onError: function (handler) {
        this._events.addHandler("onError", handler);
    },
    remove_onError: function (handler) {
        this._events.removeHandler("onError", handler);
    },
    _raiseOnBeginDownload: function (evt, context) {
        var handler = this._events.getHandler('beginDownload');
        if (handler) {
            handler(this._invoker);
        }
    },
    _raiseOnEndDownload: function () {
        var handler = this._events.getHandler('endDownload');
        if (handler) {
            handler(this._invoker);
        }
    },
    _raiseOnSuccess: function () {
        var handler = this._events.getHandler('onSuccess');
        if (handler) {
            handler(this._invoker);
        }
    },
    _raiseOnError: function (err) {
        var handler = this._events.getHandler('onError');
        if (handler) {
            handler(this._invoker, err);
        }
    },
    Download: function () {

        if (this._enableTrace)
            Sys.Debug.trace('Getting download helper object ');

        if (this._isDownloading) {
            if (this._enableTrace)
                Sys.Debug.trace('File downloading already.... ');

            return;
        }

        if (String.isNullOrEmpty(this._url)) {
            if (this._enableTrace)
                Sys.Debug.trace('Invalid URL, URL cannot be empty.');

            return;
        }

        //reset error message on every download
        AjaxDownload.ErrorMessage = '';

        //delete any client cookie
        CookieHelper.deleteCookie('downloaderror', '/', '');

        this._downloadHelper = $get('downloadHelper');

        if (this._downloadHelper) {
            document.body.removeChild(this._downloadHelper);
        }

        if (this._enableTrace)
            Sys.Debug.trace('Download helper object is null, creating a new iframe ');

        this._downloadHelper = document.createElement('iframe');
        this._downloadHelper.id = 'downloadHelper';
        this._downloadHelper.style.visibility = 'hidden';
        this._downloadHelper.style.height = '0px';
        document.body.appendChild(this._downloadHelper);
        if (this._enableTrace)
            Sys.Debug.trace('Download helper successfully created and added to DOM ');


        if (this._enableTrace)
            Sys.Debug.trace('Getting helper document');
        try {
            var doc = this._downloadHelper.contentWindow.document;
            if (doc) {
                if (this._enableTrace)
                    Sys.Debug.trace('Writing post form to helper document');
                doc.open();
                if (doc.clear != undefined)
                    doc.clear();
                doc.writeln('<html>');
                doc.writeln('<body>');
              
                var f = String.format('<form id="downloadForm" target="_blank" name="downloadForm" method="post" action="{0}">', this._url);

                doc.writeln(f);
                var params = this._params.GetKeys();
                var value = String.Empty;
                var key = String.Empty;
                for (var i in params) {
                    key = params[i];
                    value = this._params.GetValue(key);
                    var s = String.format('<input type="hidden" name="{0}" value="{1}">', key, value);
                    doc.writeln(s);
                }
                doc.writeln('<\/form>');
                doc.writeln('<\/body>');
                doc.writeln('<\/html>');
                doc.close();

                var form = doc.forms[0];
                if (form) {
                    //Track all the timers in a global accessible object
                    //Sometimes timer won't be accessible because of objects circular reference
                    if (!window._downloadTimers)
                        window._downloadTimers = new Array();

                    if (this._enableTrace)
                        Sys.Debug.trace('Raising Begin download handlers');
                    this._raiseOnBeginDownload();

                    if (this._enableTrace)
                        Sys.Debug.trace('Setting watch for the download status');

                    this._setWatch();

                    if (this._enableTrace)
                        Sys.Debug.trace('Requesting download...');


                    form.submit();
                    this._isDownloading = true;
                }
            }
            else {
                if (this._enableTrace)
                    Sys.Debug.trace('Helper document is not a valid document. ');

                this._isDownloading = false;
            }
        }
        catch (e) {
            if (this._enableTrace)
                Sys.Debug.trace('Exception: Helper document is not a valid document. ' + e.message);
            this._isDownloading = false;
        }
    },
    DownloadV2: function () {

        if (this._enableTrace)
            Sys.Debug.trace('Getting download helper object ');

        if (this._isDownloading) {
            if (this._enableTrace)
                Sys.Debug.trace('File downloading already.... ');

            return;
        }

        if (String.isNullOrEmpty(this._url)) {
            if (this._enableTrace)
                Sys.Debug.trace('Invalid URL, URL cannot be empty.');

            return;
        }

        //reset error message on every download
        AjaxDownload.ErrorMessage = '';

        //delete any client cookie
        CookieHelper.deleteCookie('downloaderror', '/', '');

        this._downloadHelper = $get('downloadHelper');

        if (this._downloadHelper) {
            document.body.removeChild(this._downloadHelper);
        }

        if (this._enableTrace)
            Sys.Debug.trace('Download helper object is null, creating a new iframe ');

        this._downloadHelper = document.createElement('iframe');
        this._downloadHelper.id = 'downloadHelper';
        this._downloadHelper.style.visibility = 'hidden';
        this._downloadHelper.style.height = '0px';
        document.body.appendChild(this._downloadHelper);
        if (this._enableTrace)
            Sys.Debug.trace('Download helper successfully created and added to DOM ');


        if (this._enableTrace)
            Sys.Debug.trace('Getting helper document');
        try {
            var doc = this._downloadHelper.contentWindow.document;
            if (doc) {
                if (this._enableTrace)
                    Sys.Debug.trace('Writing post form to helper document');
                doc.open();
                if (doc.clear != undefined)
                    doc.clear();
                doc.writeln('<html>');
                doc.writeln('<body>');

                var f = String.format('<form id="downloadForm" name="downloadForm" method="post" action="{0}">', this._url);

                doc.writeln(f);
                var params = this._params.GetKeys();
                var value = String.Empty;
                var key = String.Empty;
                for (var i in params) {
                    key = params[i];
                    value = this._params.GetValue(key);
                    var s = String.format('<input type="hidden" name="{0}" value="{1}">', key, value);
                    doc.writeln(s);
                }
                doc.writeln('<\/form>');
                doc.writeln('<\/body>');
                doc.writeln('<\/html>');
                doc.close();

                var form = doc.forms[0];
                if (form) {
                    //Track all the timers in a global accessible object
                    //Sometimes timer won't be accessible because of objects circular reference
                    if (!window._downloadTimers)
                        window._downloadTimers = new Array();

                    if (this._enableTrace)
                        Sys.Debug.trace('Raising Begin download handlers');
                    this._raiseOnBeginDownload();

                    if (this._enableTrace)
                        Sys.Debug.trace('Setting watch for the download status');

                    this._setWatch();

                    if (this._enableTrace)
                        Sys.Debug.trace('Requesting download...');


                    form.submit();
                    this._isDownloading = true;
                }
            }
            else {
                if (this._enableTrace)
                    Sys.Debug.trace('Helper document is not a valid document. ');

                this._isDownloading = false;
            }
        }
        catch (e) {
            if (this._enableTrace)
                Sys.Debug.trace('Exception: Helper document is not a valid document. ' + e.message);
            this._isDownloading = false;
        }
    },
    _setWatch: function () {
        CookieHelper.setCookie(this._cookie, 'downloading', '', '/', '', '');
        var value = CookieHelper.getCookie(this._cookie);

        if (this._enableTrace) {
            Sys.Debug.trace('Creating a watch with cookie value downloading...');
            Sys.Debug.trace('onbegindownload, cookie value....' + value);
        }
        var context = {
            sender: this,
            cookie: this._cookie,
            helper: this._downloadHelper
        };
        window._downloadTimers.push(window.setInterval(Function.createCallback(this._monitorDownload, context), 1000));
    },
    _monitorDownload: function (evt, context) {

        var obj = null;
        if (evt && evt.sender) {
            obj = evt;
            // Sys.Debug.trace('I got sender from evt '+evt.frame);
        }
        else
            if (context && context.sender) {
                obj = context;
                //  Sys.Debug.trace('I got sender from context '+context.frame);
            }
        var trace = obj.sender._enableTrace;
        try {
            if (obj.helper.contentWindow.document && obj.helper.contentWindow.document.forms[0]) {
                var value = CookieHelper.getCookie(obj.cookie);
                if (trace)
                    Sys.Debug.trace('monitoring download...., cookie value: ' + value);
                if (value != 'downloading') {
                    if (trace)
                        Sys.Debug.trace('Response received from the server, clearing timer and cookie....');
                    obj.sender._isDownloading = false;
                    obj.sender._clearDownloadTimers();
                    obj.sender._raiseOnEndDownload();
                    if (value == 'fail') {
                        if (trace)
                            Sys.Debug.trace('Response is Error, raising error handler...');

                        //var err = new Error();
                        //err.message = "Some error response received from the server while downloading....";
                        AjaxDownload.ErrorMessage = "Some error response received from the server while downloading....";
                        obj.sender._raiseOnError(err);

                    }
                    else
                        if (value == 'success') {
                            if (trace)
                                Sys.Debug.trace('Response is Success, raising success handler...');

                            try {
                                obj.sender._raiseOnSuccess();
                            }
                            catch (e) {
                                if (trace)
                                    Sys.Debug.trace('Error while raising success handler');
                            }
                        }
                }
            }
            else {
                if (trace)
                    Sys.Debug.trace('Problem in accessing download helper request, Either some URL malfunction or error occurred on the server');
                //var err = new Error();
                //err.message = "Either request failed or some error occured on the server";
                AjaxDownload.ErrorMessage = "Either request failed(invalid download path) or some error occured on the server.";
                throw new Error();
            }
        }
        catch (e) {
            if (trace)
                Sys.Debug.trace('Error thrown while downloading, Clearing timers and cookies, error:' + e.message);

            obj.sender._clearDownloadTimers();
            obj.sender._raiseOnEndDownload();
            obj.sender._raiseOnError(e);
            obj.sender._isDownloading = false;
        }
    },
    _clearDownloadTimers: function () {
        var timers = window._downloadTimers;
        while (timers.length > 0) {
            var timer = timers.pop();
            if (Object.isObject(timer)) {
                window.clearInterval(timer);
                CookieHelper.deleteCookie(this._cookie, '/', '');
            }
            timer = null;
        }
    }

}


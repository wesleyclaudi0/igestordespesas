using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class area : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A1EmpresaId = (long)(Math.Round(NumberUtil.Val( GetPar( "EmpresaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A1EmpresaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A9UsuarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "UsuarioId"), "."), 18, MidpointRounding.ToEven));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A9UsuarioId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A173UsuarioFuncaoId = (long)(Math.Round(NumberUtil.Val( GetPar( "UsuarioFuncaoId"), "."), 18, MidpointRounding.ToEven));
            n173UsuarioFuncaoId = false;
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A173UsuarioFuncaoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_usuario") == 0 )
         {
            gxnrGridlevel_usuario_newrow_invoke( ) ;
            return  ;
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7AreaId = (long)(Math.Round(NumberUtil.Val( GetPar( "AreaId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV7AreaId", StringUtil.LTrimStr( (decimal)(AV7AreaId), 18, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vAREAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AreaId), "ZZZZZZZZZZZZZZZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 18_0_9-182098", 0) ;
            }
         }
         Form.Meta.addItem("description", context.GetMessage( "Área", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAreaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_usuario_newrow_invoke( )
      {
         nRC_GXsfl_43 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_43"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_43_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_43_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_43_idx = GetPar( "sGXsfl_43_idx");
         edtUsuarioId_Horizontalalignment = GetNextPar( );
         AssignProp("", false, edtUsuarioId_Internalname, "Horizontalalignment", edtUsuarioId_Horizontalalignment, !bGXsfl_43_Refreshing);
         A692AreaLine = (short)(Math.Round(NumberUtil.Val( GetPar( "AreaLine"), "."), 18, MidpointRounding.ToEven));
         Gx_BScreen = (short)(Math.Round(NumberUtil.Val( GetPar( "Gx_BScreen"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_usuario_newrow( ) ;
         /* End function gxnrGridlevel_usuario_newrow_invoke */
      }

      public area( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public area( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_AreaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7AreaId = aP1_AreaId;
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkAreaAtivo = new GXCheckbox();
         cmbUsuarioPerfil = new GXCombobox();
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityLow ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
         A691AreaAtivo = StringUtil.StrToBool( StringUtil.BoolToStr( A691AreaAtivo));
         AssignAttri("", false, "A691AreaAtivo", A691AreaAtivo);
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "TableContent", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucGxuitabspanel_tabs1.SetProperty("PageCount", Gxuitabspanel_tabs1_Pagecount);
         ucGxuitabspanel_tabs1.SetProperty("Class", Gxuitabspanel_tabs1_Class);
         ucGxuitabspanel_tabs1.SetProperty("HistoryManagement", Gxuitabspanel_tabs1_Historymanagement);
         ucGxuitabspanel_tabs1.Render(context, "tab", Gxuitabspanel_tabs1_Internalname, "GXUITABSPANEL_TABS1Container");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title1"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTab1_title_Internalname, context.GetMessage( "Geral", ""), "", "", lblTab1_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Area.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "Tab1") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel1"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAreaNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAreaNome_Internalname, context.GetMessage( "Nome", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAreaNome_Internalname, StringUtil.RTrim( A690AreaNome), StringUtil.RTrim( context.localUtil.Format( A690AreaNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAreaNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAreaNome_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nome", "start", true, "", "HLP_Area.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAreaEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAreaEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAreaEmail_Internalname, A746AreaEmail, StringUtil.RTrim( context.localUtil.Format( A746AreaEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A746AreaEmail, "", "", "", edtAreaEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAreaEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Area.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkAreaAtivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkAreaAtivo_Internalname, context.GetMessage( "Ativo", ""), "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkAreaAtivo_Internalname, StringUtil.BoolToStr( A691AreaAtivo), "", context.GetMessage( "Ativo", ""), 1, chkAreaAtivo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(35, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,35);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"title2"+"\" style=\"display:none;\">") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTab2_title_Internalname, context.GetMessage( "Usuários", ""), "", "", lblTab2_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_Area.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
         context.WriteHtmlText( "Tab2") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABS1Container"+"panel2"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell", "start", "top", "", "", "div");
         gxdraw_Gridlevel_usuario( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group TrnActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtntrn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Area.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtntrn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Area.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtntrn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Area.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_usuarioid.SetProperty("Caption", Combo_usuarioid_Caption);
         ucCombo_usuarioid.SetProperty("Cls", Combo_usuarioid_Cls);
         ucCombo_usuarioid.SetProperty("IsGridItem", Combo_usuarioid_Isgriditem);
         ucCombo_usuarioid.SetProperty("EmptyItemText", Combo_usuarioid_Emptyitemtext);
         ucCombo_usuarioid.SetProperty("DropDownOptionsData", AV17UsuarioId_Data);
         ucCombo_usuarioid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_usuarioid_Internalname, "COMBO_USUARIOIDContainer");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAreaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A689AreaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtAreaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A689AreaId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A689AreaId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAreaId_Jsonclick, 0, "Attribute", "", "", "", "", edtAreaId_Visible, edtAreaId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, 0, true, "Id", "end", false, "", "HLP_Area.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAreaLine_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A692AreaLine), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtAreaLine_Enabled!=0) ? context.localUtil.Format( (decimal)(A692AreaLine), "ZZZ9") : context.localUtil.Format( (decimal)(A692AreaLine), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAreaLine_Jsonclick, 0, "Attribute", "", "", "", "", edtAreaLine_Visible, edtAreaLine_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "end", false, "", "HLP_Area.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpresaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1EmpresaId), "ZZZZZZZZZZZZZZZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpresaId_Jsonclick, 0, "Attribute", "", "", "", "", edtEmpresaId_Visible, edtEmpresaId_Enabled, 1, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, 0, true, "Id", "end", false, "", "HLP_Area.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEmpresaNome_Internalname, StringUtil.RTrim( A2EmpresaNome), StringUtil.RTrim( context.localUtil.Format( A2EmpresaNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpresaNome_Jsonclick, 0, "Attribute", "", "", "", "", edtEmpresaNome_Visible, edtEmpresaNome_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nome", "start", true, "", "HLP_Area.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_usuario( )
      {
         /*  Grid Control  */
         StartGridControl43( ) ;
         nGXsfl_43_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount102 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_102 = 1;
               ScanStart2K102( ) ;
               while ( RcdFound102 != 0 )
               {
                  init_level_properties102( ) ;
                  getByPrimaryKey2K102( ) ;
                  AddRow2K102( ) ;
                  ScanNext2K102( ) ;
               }
               ScanEnd2K102( ) ;
               nBlankRcdCount102 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B692AreaLine = A692AreaLine;
            AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
            standaloneNotModal2K102( ) ;
            standaloneModal2K102( ) ;
            sMode102 = Gx_mode;
            while ( nGXsfl_43_idx < nRC_GXsfl_43 )
            {
               bGXsfl_43_Refreshing = true;
               ReadRow2K102( ) ;
               edtAreaUsuarioId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AREAUSUARIOID_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtAreaUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaUsuarioId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtUsuarioId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOID_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtUsuarioId_Horizontalalignment = cgiGet( "USUARIOID_"+sGXsfl_43_idx+"Horizontalalignment");
               AssignProp("", false, edtUsuarioId_Internalname, "Horizontalalignment", edtUsuarioId_Horizontalalignment, !bGXsfl_43_Refreshing);
               edtUsuarioNome_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIONOME_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtUsuarioNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNome_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               cmbUsuarioPerfil.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOPERFIL_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, cmbUsuarioPerfil_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuarioPerfil.Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtUsuarioFuncaoNome_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOFUNCAONOME_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtUsuarioFuncaoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFuncaoNome_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               edtUsuarioFuncaoId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOFUNCAOID_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtUsuarioFuncaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFuncaoId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
               if ( ( nRcdExists_102 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal2K102( ) ;
               }
               SendRow2K102( ) ;
               bGXsfl_43_Refreshing = false;
            }
            Gx_mode = sMode102;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A692AreaLine = B692AreaLine;
            AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount102 = 5;
            nRcdExists_102 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart2K102( ) ;
               while ( RcdFound102 != 0 )
               {
                  sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_43102( ) ;
                  init_level_properties102( ) ;
                  standaloneNotModal2K102( ) ;
                  getByPrimaryKey2K102( ) ;
                  standaloneModal2K102( ) ;
                  AddRow2K102( ) ;
                  ScanNext2K102( ) ;
               }
               ScanEnd2K102( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode102 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx+1), 4, 0), 4, "0");
            SubsflControlProps_43102( ) ;
            InitAll2K102( ) ;
            init_level_properties102( ) ;
            B692AreaLine = A692AreaLine;
            AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
            nRcdExists_102 = 0;
            nIsMod_102 = 0;
            nRcdDeleted_102 = 0;
            nBlankRcdCount102 = (short)(nBlankRcdUsr102+nBlankRcdCount102);
            fRowAdded = 0;
            while ( nBlankRcdCount102 > 0 )
            {
               standaloneNotModal2K102( ) ;
               standaloneModal2K102( ) ;
               AddRow2K102( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtUsuarioId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount102 = (short)(nBlankRcdCount102-1);
            }
            Gx_mode = sMode102;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A692AreaLine = B692AreaLine;
            AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_usuarioContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_usuario", Gridlevel_usuarioContainer, subGridlevel_usuario_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_usuarioContainerData", Gridlevel_usuarioContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_usuarioContainerData"+"V", Gridlevel_usuarioContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_usuarioContainerData"+"V"+"\" value='"+Gridlevel_usuarioContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112K2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vUSUARIOID_DATA"), AV17UsuarioId_Data);
               /* Read saved values. */
               Z689AreaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z689AreaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z690AreaNome = cgiGet( "Z690AreaNome");
               Z691AreaAtivo = StringUtil.StrToBool( cgiGet( "Z691AreaAtivo"));
               Z692AreaLine = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z692AreaLine"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Z746AreaEmail = cgiGet( "Z746AreaEmail");
               Z1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z1EmpresaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               O692AreaLine = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O692AreaLine"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_43 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_43"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               N1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "N1EmpresaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV7AreaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vAREAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV13Insert_EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_EMPRESAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV15EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vEMPRESAID"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AV21Pgmname = cgiGet( "vPGMNAME");
               A16UsuarioEmail = cgiGet( "USUARIOEMAIL");
               A14UsuarioAtivo = StringUtil.StrToBool( cgiGet( "USUARIOATIVO"));
               Gxuitabspanel_tabs1_Objectcall = cgiGet( "GXUITABSPANEL_TABS1_Objectcall");
               Gxuitabspanel_tabs1_Enabled = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS1_Enabled"));
               Gxuitabspanel_tabs1_Activepage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS1_Activepage"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_tabs1_Activepagecontrolname = cgiGet( "GXUITABSPANEL_TABS1_Activepagecontrolname");
               Gxuitabspanel_tabs1_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS1_Pagecount"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Gxuitabspanel_tabs1_Class = cgiGet( "GXUITABSPANEL_TABS1_Class");
               Gxuitabspanel_tabs1_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS1_Historymanagement"));
               Gxuitabspanel_tabs1_Visible = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS1_Visible"));
               Combo_usuarioid_Objectcall = cgiGet( "COMBO_USUARIOID_Objectcall");
               Combo_usuarioid_Class = cgiGet( "COMBO_USUARIOID_Class");
               Combo_usuarioid_Icontype = cgiGet( "COMBO_USUARIOID_Icontype");
               Combo_usuarioid_Icon = cgiGet( "COMBO_USUARIOID_Icon");
               Combo_usuarioid_Caption = cgiGet( "COMBO_USUARIOID_Caption");
               Combo_usuarioid_Tooltip = cgiGet( "COMBO_USUARIOID_Tooltip");
               Combo_usuarioid_Cls = cgiGet( "COMBO_USUARIOID_Cls");
               Combo_usuarioid_Selectedvalue_set = cgiGet( "COMBO_USUARIOID_Selectedvalue_set");
               Combo_usuarioid_Selectedvalue_get = cgiGet( "COMBO_USUARIOID_Selectedvalue_get");
               Combo_usuarioid_Selectedtext_set = cgiGet( "COMBO_USUARIOID_Selectedtext_set");
               Combo_usuarioid_Selectedtext_get = cgiGet( "COMBO_USUARIOID_Selectedtext_get");
               Combo_usuarioid_Gamoauthtoken = cgiGet( "COMBO_USUARIOID_Gamoauthtoken");
               Combo_usuarioid_Ddointernalname = cgiGet( "COMBO_USUARIOID_Ddointernalname");
               Combo_usuarioid_Titlecontrolalign = cgiGet( "COMBO_USUARIOID_Titlecontrolalign");
               Combo_usuarioid_Dropdownoptionstype = cgiGet( "COMBO_USUARIOID_Dropdownoptionstype");
               Combo_usuarioid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_USUARIOID_Enabled"));
               Combo_usuarioid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_USUARIOID_Visible"));
               Combo_usuarioid_Titlecontrolidtoreplace = cgiGet( "COMBO_USUARIOID_Titlecontrolidtoreplace");
               Combo_usuarioid_Datalisttype = cgiGet( "COMBO_USUARIOID_Datalisttype");
               Combo_usuarioid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_USUARIOID_Allowmultipleselection"));
               Combo_usuarioid_Datalistfixedvalues = cgiGet( "COMBO_USUARIOID_Datalistfixedvalues");
               Combo_usuarioid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_USUARIOID_Isgriditem"));
               Combo_usuarioid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_USUARIOID_Hasdescription"));
               Combo_usuarioid_Datalistproc = cgiGet( "COMBO_USUARIOID_Datalistproc");
               Combo_usuarioid_Datalistprocparametersprefix = cgiGet( "COMBO_USUARIOID_Datalistprocparametersprefix");
               Combo_usuarioid_Remoteservicesparameters = cgiGet( "COMBO_USUARIOID_Remoteservicesparameters");
               Combo_usuarioid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_USUARIOID_Datalistupdateminimumcharacters"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               Combo_usuarioid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_USUARIOID_Includeonlyselectedoption"));
               Combo_usuarioid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_USUARIOID_Includeselectalloption"));
               Combo_usuarioid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_USUARIOID_Emptyitem"));
               Combo_usuarioid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_USUARIOID_Includeaddnewoption"));
               Combo_usuarioid_Htmltemplate = cgiGet( "COMBO_USUARIOID_Htmltemplate");
               Combo_usuarioid_Multiplevaluestype = cgiGet( "COMBO_USUARIOID_Multiplevaluestype");
               Combo_usuarioid_Loadingdata = cgiGet( "COMBO_USUARIOID_Loadingdata");
               Combo_usuarioid_Noresultsfound = cgiGet( "COMBO_USUARIOID_Noresultsfound");
               Combo_usuarioid_Emptyitemtext = cgiGet( "COMBO_USUARIOID_Emptyitemtext");
               Combo_usuarioid_Onlyselectedvalues = cgiGet( "COMBO_USUARIOID_Onlyselectedvalues");
               Combo_usuarioid_Selectalltext = cgiGet( "COMBO_USUARIOID_Selectalltext");
               Combo_usuarioid_Multiplevaluesseparator = cgiGet( "COMBO_USUARIOID_Multiplevaluesseparator");
               Combo_usuarioid_Addnewoptiontext = cgiGet( "COMBO_USUARIOID_Addnewoptiontext");
               Combo_usuarioid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_USUARIOID_Gxcontroltype"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A690AreaNome = cgiGet( edtAreaNome_Internalname);
               AssignAttri("", false, "A690AreaNome", A690AreaNome);
               A746AreaEmail = cgiGet( edtAreaEmail_Internalname);
               AssignAttri("", false, "A746AreaEmail", A746AreaEmail);
               A691AreaAtivo = StringUtil.StrToBool( cgiGet( chkAreaAtivo_Internalname));
               AssignAttri("", false, "A691AreaAtivo", A691AreaAtivo);
               A689AreaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAreaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
               A692AreaLine = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAreaLine_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtEmpresaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEmpresaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPRESAID");
                  AnyError = 1;
                  GX_FocusControl = edtEmpresaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1EmpresaId = 0;
                  AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 18, 0));
               }
               else
               {
                  A1EmpresaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtEmpresaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 18, 0));
               }
               A2EmpresaNome = cgiGet( edtEmpresaNome_Internalname);
               AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Area");
               A689AreaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAreaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
               forbiddenHiddens.Add("AreaId", context.localUtil.Format( (decimal)(A689AreaId), "ZZZZZZZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A689AreaId != Z689AreaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("area:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A689AreaId = (long)(Math.Round(NumberUtil.Val( GetPar( "AreaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode101 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode101;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound101 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2K0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "AREAID");
                        AnyError = 1;
                        GX_FocusControl = edtAreaId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E112K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E122K2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2K101( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes2K101( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_2K0( )
      {
         BeforeValidate2K101( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2K101( ) ;
            }
            else
            {
               CheckExtendedTable2K101( ) ;
               CloseExtendedTableCursors2K101( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode101 = Gx_mode;
            CONFIRM_2K102( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode101;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode101;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_2K102( )
      {
         s692AreaLine = O692AreaLine;
         AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
         nGXsfl_43_idx = 0;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            ReadRow2K102( ) ;
            if ( ( nRcdExists_102 != 0 ) || ( nIsMod_102 != 0 ) )
            {
               GetKey2K102( ) ;
               if ( ( nRcdExists_102 == 0 ) && ( nRcdDeleted_102 == 0 ) )
               {
                  if ( RcdFound102 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate2K102( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable2K102( ) ;
                        CloseExtendedTableCursors2K102( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O692AreaLine = A692AreaLine;
                        AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound102 != 0 )
                  {
                     if ( nRcdDeleted_102 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey2K102( ) ;
                        Load2K102( ) ;
                        BeforeValidate2K102( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls2K102( ) ;
                           O692AreaLine = A692AreaLine;
                           AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_102 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate2K102( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable2K102( ) ;
                              CloseExtendedTableCursors2K102( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O692AreaLine = A692AreaLine;
                              AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_102 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtAreaUsuarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A693AreaUsuarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtUsuarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9UsuarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtUsuarioNome_Internalname, StringUtil.RTrim( A10UsuarioNome)) ;
            ChangePostValue( cmbUsuarioPerfil_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuarioPerfil), 4, 0, ".", ""))) ;
            ChangePostValue( edtUsuarioFuncaoNome_Internalname, StringUtil.RTrim( A174UsuarioFuncaoNome)) ;
            ChangePostValue( edtUsuarioFuncaoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A173UsuarioFuncaoId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z693AreaUsuarioId_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z693AreaUsuarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z9UsuarioId_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9UsuarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_102_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_102), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_102_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_102), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_102_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_102), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_102 != 0 )
            {
               ChangePostValue( "AREAUSUARIOID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAreaUsuarioId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOID_"+sGXsfl_43_idx+"Horizontalalignment", StringUtil.RTrim( edtUsuarioId_Horizontalalignment)) ;
               ChangePostValue( "USUARIONOME_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioNome_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOPERFIL_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbUsuarioPerfil.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOFUNCAONOME_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioFuncaoNome_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOFUNCAOID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioFuncaoId_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O692AreaLine = s692AreaLine;
         AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption2K0( )
      {
      }

      protected void E112K2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV16SDTContexto.FromJSonString(AV12WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
         AV15EmpresaId = AV16SDTContexto.gxTpr_Empresaid;
         AssignAttri("", false, "AV15EmpresaId", StringUtil.LTrimStr( (decimal)(AV15EmpresaId), 18, 0));
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         Combo_usuarioid_Titlecontrolidtoreplace = edtUsuarioId_Internalname;
         ucCombo_usuarioid.SendProperty(context, "", false, Combo_usuarioid_Internalname, "TitleControlIdToReplace", Combo_usuarioid_Titlecontrolidtoreplace);
         edtUsuarioId_Horizontalalignment = "Left";
         AssignProp("", false, edtUsuarioId_Internalname, "Horizontalalignment", edtUsuarioId_Horizontalalignment, !bGXsfl_43_Refreshing);
         /* Execute user subroutine: 'LOADCOMBOUSUARIOID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV21Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV22GXV1 = 1;
            AssignAttri("", false, "AV22GXV1", StringUtil.LTrimStr( (decimal)(AV22GXV1), 8, 0));
            while ( AV22GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV22GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "EmpresaId") == 0 )
               {
                  AV13Insert_EmpresaId = (long)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_EmpresaId", StringUtil.LTrimStr( (decimal)(AV13Insert_EmpresaId), 18, 0));
               }
               AV22GXV1 = (int)(AV22GXV1+1);
               AssignAttri("", false, "AV22GXV1", StringUtil.LTrimStr( (decimal)(AV22GXV1), 8, 0));
            }
         }
         edtAreaId_Visible = 0;
         AssignProp("", false, edtAreaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAreaId_Visible), 5, 0), true);
         edtAreaLine_Visible = 0;
         AssignProp("", false, edtAreaLine_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtAreaLine_Visible), 5, 0), true);
         edtEmpresaId_Visible = 0;
         AssignProp("", false, edtEmpresaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Visible), 5, 0), true);
         edtEmpresaNome_Visible = 0;
         AssignProp("", false, edtEmpresaNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Visible), 5, 0), true);
      }

      protected void E122K2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("areaww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOUSUARIOID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV17UsuarioId_Data;
         new arealoaddvcombo(context ).execute(  "UsuarioId",  Gx_mode,  AV7AreaId, out  AV18ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AV17UsuarioId_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
      }

      protected void ZM2K101( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z690AreaNome = T002K7_A690AreaNome[0];
               Z691AreaAtivo = T002K7_A691AreaAtivo[0];
               Z692AreaLine = T002K7_A692AreaLine[0];
               Z746AreaEmail = T002K7_A746AreaEmail[0];
               Z1EmpresaId = T002K7_A1EmpresaId[0];
            }
            else
            {
               Z690AreaNome = A690AreaNome;
               Z691AreaAtivo = A691AreaAtivo;
               Z692AreaLine = A692AreaLine;
               Z746AreaEmail = A746AreaEmail;
               Z1EmpresaId = A1EmpresaId;
            }
         }
         if ( GX_JID == -18 )
         {
            Z689AreaId = A689AreaId;
            Z690AreaNome = A690AreaNome;
            Z691AreaAtivo = A691AreaAtivo;
            Z692AreaLine = A692AreaLine;
            Z746AreaEmail = A746AreaEmail;
            Z1EmpresaId = A1EmpresaId;
            Z2EmpresaNome = A2EmpresaNome;
         }
      }

      protected void standaloneNotModal( )
      {
         edtAreaId_Enabled = 0;
         AssignProp("", false, edtAreaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaId_Enabled), 5, 0), true);
         edtAreaLine_Enabled = 0;
         AssignProp("", false, edtAreaLine_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaLine_Enabled), 5, 0), true);
         AV21Pgmname = "Area";
         AssignAttri("", false, "AV21Pgmname", AV21Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtAreaId_Enabled = 0;
         AssignProp("", false, edtAreaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaId_Enabled), 5, 0), true);
         edtAreaLine_Enabled = 0;
         AssignProp("", false, edtAreaLine_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaLine_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7AreaId) )
         {
            A689AreaId = AV7AreaId;
            AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_EmpresaId) )
         {
            edtEmpresaId_Enabled = 0;
            AssignProp("", false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), true);
         }
         else
         {
            edtEmpresaId_Enabled = 1;
            AssignProp("", false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_EmpresaId) )
         {
            A1EmpresaId = AV13Insert_EmpresaId;
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 18, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A1EmpresaId) && ( Gx_BScreen == 0 ) )
            {
               A1EmpresaId = AV15EmpresaId;
               AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 18, 0));
            }
         }
         if ( IsIns( )  && (false==A691AreaAtivo) && ( Gx_BScreen == 0 ) )
         {
            A691AreaAtivo = true;
            AssignAttri("", false, "A691AreaAtivo", A691AreaAtivo);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T002K8 */
            pr_default.execute(6, new Object[] {A1EmpresaId});
            A2EmpresaNome = T002K8_A2EmpresaNome[0];
            AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
            pr_default.close(6);
         }
      }

      protected void Load2K101( )
      {
         /* Using cursor T002K9 */
         pr_default.execute(7, new Object[] {A689AreaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound101 = 1;
            A690AreaNome = T002K9_A690AreaNome[0];
            AssignAttri("", false, "A690AreaNome", A690AreaNome);
            A691AreaAtivo = T002K9_A691AreaAtivo[0];
            AssignAttri("", false, "A691AreaAtivo", A691AreaAtivo);
            A692AreaLine = T002K9_A692AreaLine[0];
            AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
            A746AreaEmail = T002K9_A746AreaEmail[0];
            AssignAttri("", false, "A746AreaEmail", A746AreaEmail);
            A2EmpresaNome = T002K9_A2EmpresaNome[0];
            AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
            A1EmpresaId = T002K9_A1EmpresaId[0];
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 18, 0));
            ZM2K101( -18) ;
         }
         pr_default.close(7);
         OnLoadActions2K101( ) ;
      }

      protected void OnLoadActions2K101( )
      {
      }

      protected void CheckExtendedTable2K101( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A690AreaNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "WWP_RequiredAttribute", ""), context.GetMessage( "Nome", ""), "", "", "", "", "", "", "", ""), 1, "AREANOME");
            AnyError = 1;
            GX_FocusControl = edtAreaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A746AreaEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXM_DoesNotMatchRegExp", ""), context.GetMessage( "Area Email", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "AREAEMAIL");
            AnyError = 1;
            GX_FocusControl = edtAreaEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002K8 */
         pr_default.execute(6, new Object[] {A1EmpresaId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Empresa", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2EmpresaNome = T002K8_A2EmpresaNome[0];
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors2K101( )
      {
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_19( long A1EmpresaId )
      {
         /* Using cursor T002K10 */
         pr_default.execute(8, new Object[] {A1EmpresaId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Empresa", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2EmpresaNome = T002K10_A2EmpresaNome[0];
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2EmpresaNome))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey2K101( )
      {
         /* Using cursor T002K11 */
         pr_default.execute(9, new Object[] {A689AreaId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound101 = 1;
         }
         else
         {
            RcdFound101 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002K7 */
         pr_default.execute(5, new Object[] {A689AreaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM2K101( 18) ;
            RcdFound101 = 1;
            A689AreaId = T002K7_A689AreaId[0];
            AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
            A690AreaNome = T002K7_A690AreaNome[0];
            AssignAttri("", false, "A690AreaNome", A690AreaNome);
            A691AreaAtivo = T002K7_A691AreaAtivo[0];
            AssignAttri("", false, "A691AreaAtivo", A691AreaAtivo);
            A692AreaLine = T002K7_A692AreaLine[0];
            AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
            A746AreaEmail = T002K7_A746AreaEmail[0];
            AssignAttri("", false, "A746AreaEmail", A746AreaEmail);
            A1EmpresaId = T002K7_A1EmpresaId[0];
            AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 18, 0));
            O692AreaLine = A692AreaLine;
            AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
            Z689AreaId = A689AreaId;
            sMode101 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2K101( ) ;
            if ( AnyError == 1 )
            {
               RcdFound101 = 0;
               InitializeNonKey2K101( ) ;
            }
            Gx_mode = sMode101;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound101 = 0;
            InitializeNonKey2K101( ) ;
            sMode101 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode101;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey2K101( ) ;
         if ( RcdFound101 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound101 = 0;
         /* Using cursor T002K12 */
         pr_default.execute(10, new Object[] {A689AreaId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T002K12_A689AreaId[0] < A689AreaId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T002K12_A689AreaId[0] > A689AreaId ) ) )
            {
               A689AreaId = T002K12_A689AreaId[0];
               AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
               RcdFound101 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound101 = 0;
         /* Using cursor T002K13 */
         pr_default.execute(11, new Object[] {A689AreaId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T002K13_A689AreaId[0] > A689AreaId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T002K13_A689AreaId[0] < A689AreaId ) ) )
            {
               A689AreaId = T002K13_A689AreaId[0];
               AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
               RcdFound101 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2K101( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A692AreaLine = O692AreaLine;
            AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
            GX_FocusControl = edtAreaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2K101( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound101 == 1 )
            {
               if ( A689AreaId != Z689AreaId )
               {
                  A689AreaId = Z689AreaId;
                  AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AREAID");
                  AnyError = 1;
                  GX_FocusControl = edtAreaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A692AreaLine = O692AreaLine;
                  AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAreaNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A692AreaLine = O692AreaLine;
                  AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
                  Update2K101( ) ;
                  GX_FocusControl = edtAreaNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A689AreaId != Z689AreaId )
               {
                  /* Insert record */
                  A692AreaLine = O692AreaLine;
                  AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
                  GX_FocusControl = edtAreaNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2K101( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AREAID");
                     AnyError = 1;
                     GX_FocusControl = edtAreaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A692AreaLine = O692AreaLine;
                     AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
                     GX_FocusControl = edtAreaNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2K101( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A689AreaId != Z689AreaId )
         {
            A689AreaId = Z689AreaId;
            AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AREAID");
            AnyError = 1;
            GX_FocusControl = edtAreaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A692AreaLine = O692AreaLine;
            AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAreaNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2K101( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002K6 */
            pr_default.execute(4, new Object[] {A689AreaId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Area"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( StringUtil.StrCmp(Z690AreaNome, T002K6_A690AreaNome[0]) != 0 ) || ( Z691AreaAtivo != T002K6_A691AreaAtivo[0] ) || ( Z692AreaLine != T002K6_A692AreaLine[0] ) || ( StringUtil.StrCmp(Z746AreaEmail, T002K6_A746AreaEmail[0]) != 0 ) || ( Z1EmpresaId != T002K6_A1EmpresaId[0] ) )
            {
               if ( StringUtil.StrCmp(Z690AreaNome, T002K6_A690AreaNome[0]) != 0 )
               {
                  GXUtil.WriteLog("area:[seudo value changed for attri]"+"AreaNome");
                  GXUtil.WriteLogRaw("Old: ",Z690AreaNome);
                  GXUtil.WriteLogRaw("Current: ",T002K6_A690AreaNome[0]);
               }
               if ( Z691AreaAtivo != T002K6_A691AreaAtivo[0] )
               {
                  GXUtil.WriteLog("area:[seudo value changed for attri]"+"AreaAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z691AreaAtivo);
                  GXUtil.WriteLogRaw("Current: ",T002K6_A691AreaAtivo[0]);
               }
               if ( Z692AreaLine != T002K6_A692AreaLine[0] )
               {
                  GXUtil.WriteLog("area:[seudo value changed for attri]"+"AreaLine");
                  GXUtil.WriteLogRaw("Old: ",Z692AreaLine);
                  GXUtil.WriteLogRaw("Current: ",T002K6_A692AreaLine[0]);
               }
               if ( StringUtil.StrCmp(Z746AreaEmail, T002K6_A746AreaEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("area:[seudo value changed for attri]"+"AreaEmail");
                  GXUtil.WriteLogRaw("Old: ",Z746AreaEmail);
                  GXUtil.WriteLogRaw("Current: ",T002K6_A746AreaEmail[0]);
               }
               if ( Z1EmpresaId != T002K6_A1EmpresaId[0] )
               {
                  GXUtil.WriteLog("area:[seudo value changed for attri]"+"EmpresaId");
                  GXUtil.WriteLogRaw("Old: ",Z1EmpresaId);
                  GXUtil.WriteLogRaw("Current: ",T002K6_A1EmpresaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Area"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2K101( )
      {
         BeforeValidate2K101( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2K101( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2K101( 0) ;
            CheckOptimisticConcurrency2K101( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2K101( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2K101( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002K14 */
                     pr_default.execute(12, new Object[] {A690AreaNome, A691AreaAtivo, A692AreaLine, A746AreaEmail, A1EmpresaId});
                     A689AreaId = T002K14_A689AreaId[0];
                     AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Area");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2K101( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption2K0( ) ;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load2K101( ) ;
            }
            EndLevel2K101( ) ;
         }
         CloseExtendedTableCursors2K101( ) ;
      }

      protected void Update2K101( )
      {
         BeforeValidate2K101( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2K101( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2K101( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2K101( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2K101( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002K15 */
                     pr_default.execute(13, new Object[] {A690AreaNome, A691AreaAtivo, A692AreaLine, A746AreaEmail, A1EmpresaId, A689AreaId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("Area");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Area"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2K101( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2K101( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel2K101( ) ;
         }
         CloseExtendedTableCursors2K101( ) ;
      }

      protected void DeferredUpdate2K101( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2K101( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2K101( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2K101( ) ;
            AfterConfirm2K101( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2K101( ) ;
               if ( AnyError == 0 )
               {
                  A692AreaLine = O692AreaLine;
                  AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
                  ScanStart2K102( ) ;
                  while ( RcdFound102 != 0 )
                  {
                     getByPrimaryKey2K102( ) ;
                     Delete2K102( ) ;
                     ScanNext2K102( ) ;
                     O692AreaLine = A692AreaLine;
                     AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
                  }
                  ScanEnd2K102( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002K16 */
                     pr_default.execute(14, new Object[] {A689AreaId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("Area");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
         sMode101 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2K101( ) ;
         Gx_mode = sMode101;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2K101( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002K17 */
            pr_default.execute(15, new Object[] {A1EmpresaId});
            A2EmpresaNome = T002K17_A2EmpresaNome[0];
            AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002K18 */
            pr_default.execute(16, new Object[] {A689AreaId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {context.GetMessage( "Documento", "")}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void ProcessNestedLevel2K102( )
      {
         s692AreaLine = O692AreaLine;
         AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
         nGXsfl_43_idx = 0;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            ReadRow2K102( ) ;
            if ( ( nRcdExists_102 != 0 ) || ( nIsMod_102 != 0 ) )
            {
               standaloneNotModal2K102( ) ;
               GetKey2K102( ) ;
               if ( ( nRcdExists_102 == 0 ) && ( nRcdDeleted_102 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert2K102( ) ;
               }
               else
               {
                  if ( RcdFound102 != 0 )
                  {
                     if ( ( nRcdDeleted_102 != 0 ) && ( nRcdExists_102 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete2K102( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_102 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update2K102( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_102 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               O692AreaLine = A692AreaLine;
               AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
            }
            ChangePostValue( edtAreaUsuarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A693AreaUsuarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtUsuarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9UsuarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( edtUsuarioNome_Internalname, StringUtil.RTrim( A10UsuarioNome)) ;
            ChangePostValue( cmbUsuarioPerfil_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuarioPerfil), 4, 0, ".", ""))) ;
            ChangePostValue( edtUsuarioFuncaoNome_Internalname, StringUtil.RTrim( A174UsuarioFuncaoNome)) ;
            ChangePostValue( edtUsuarioFuncaoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A173UsuarioFuncaoId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z693AreaUsuarioId_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z693AreaUsuarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "ZT_"+"Z9UsuarioId_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9UsuarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdDeleted_102_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_102), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nRcdExists_102_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_102), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            ChangePostValue( "nIsMod_102_"+sGXsfl_43_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_102), 4, 0, context.GetLanguageProperty( "decimal_point"), ""))) ;
            if ( nIsMod_102 != 0 )
            {
               ChangePostValue( "AREAUSUARIOID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAreaUsuarioId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOID_"+sGXsfl_43_idx+"Horizontalalignment", StringUtil.RTrim( edtUsuarioId_Horizontalalignment)) ;
               ChangePostValue( "USUARIONOME_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioNome_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOPERFIL_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbUsuarioPerfil.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOFUNCAONOME_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioFuncaoNome_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUARIOFUNCAOID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioFuncaoId_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll2K102( ) ;
         if ( AnyError != 0 )
         {
            O692AreaLine = s692AreaLine;
            AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
         }
         nRcdExists_102 = 0;
         nIsMod_102 = 0;
         nRcdDeleted_102 = 0;
      }

      protected void ProcessLevel2K101( )
      {
         /* Save parent mode. */
         sMode101 = Gx_mode;
         ProcessNestedLevel2K102( ) ;
         if ( AnyError != 0 )
         {
            O692AreaLine = s692AreaLine;
            AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode101;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T002K19 */
         pr_default.execute(17, new Object[] {A692AreaLine, A689AreaId});
         pr_default.close(17);
         pr_default.SmartCacheProvider.SetUpdated("Area");
      }

      protected void EndLevel2K101( )
      {
         pr_default.close(4);
         if ( AnyError == 0 )
         {
            BeforeComplete2K101( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(15);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("area",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2K0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(15);
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("area",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2K101( )
      {
         /* Scan By routine */
         /* Using cursor T002K20 */
         pr_default.execute(18);
         RcdFound101 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound101 = 1;
            A689AreaId = T002K20_A689AreaId[0];
            AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2K101( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound101 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound101 = 1;
            A689AreaId = T002K20_A689AreaId[0];
            AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
         }
      }

      protected void ScanEnd2K101( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm2K101( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2K101( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2K101( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2K101( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2K101( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2K101( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2K101( )
      {
         edtAreaNome_Enabled = 0;
         AssignProp("", false, edtAreaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaNome_Enabled), 5, 0), true);
         edtAreaEmail_Enabled = 0;
         AssignProp("", false, edtAreaEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaEmail_Enabled), 5, 0), true);
         chkAreaAtivo.Enabled = 0;
         AssignProp("", false, chkAreaAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkAreaAtivo.Enabled), 5, 0), true);
         edtAreaId_Enabled = 0;
         AssignProp("", false, edtAreaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaId_Enabled), 5, 0), true);
         edtAreaLine_Enabled = 0;
         AssignProp("", false, edtAreaLine_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaLine_Enabled), 5, 0), true);
         edtEmpresaId_Enabled = 0;
         AssignProp("", false, edtEmpresaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaId_Enabled), 5, 0), true);
         edtEmpresaNome_Enabled = 0;
         AssignProp("", false, edtEmpresaNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpresaNome_Enabled), 5, 0), true);
      }

      protected void ZM2K102( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z9UsuarioId = T002K3_A9UsuarioId[0];
            }
            else
            {
               Z9UsuarioId = A9UsuarioId;
            }
         }
         if ( GX_JID == -20 )
         {
            Z689AreaId = A689AreaId;
            Z693AreaUsuarioId = A693AreaUsuarioId;
            Z9UsuarioId = A9UsuarioId;
            Z10UsuarioNome = A10UsuarioNome;
            Z11UsuarioPerfil = A11UsuarioPerfil;
            Z16UsuarioEmail = A16UsuarioEmail;
            Z14UsuarioAtivo = A14UsuarioAtivo;
            Z173UsuarioFuncaoId = A173UsuarioFuncaoId;
            Z174UsuarioFuncaoNome = A174UsuarioFuncaoNome;
         }
      }

      protected void standaloneNotModal2K102( )
      {
         edtAreaUsuarioId_Enabled = 0;
         AssignProp("", false, edtAreaUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaUsuarioId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtUsuarioNome_Enabled = 0;
         AssignProp("", false, edtUsuarioNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNome_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtUsuarioFuncaoId_Enabled = 0;
         AssignProp("", false, edtUsuarioFuncaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFuncaoId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtAreaLine_Enabled = 0;
         AssignProp("", false, edtAreaLine_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaLine_Enabled), 5, 0), true);
         edtAreaLine_Enabled = 0;
         AssignProp("", false, edtAreaLine_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaLine_Enabled), 5, 0), true);
      }

      protected void standaloneModal2K102( )
      {
         if ( IsIns( )  )
         {
            A692AreaLine = (short)(O692AreaLine+1);
            AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A693AreaUsuarioId = A692AreaLine;
         }
      }

      protected void Load2K102( )
      {
         /* Using cursor T002K21 */
         pr_default.execute(19, new Object[] {A689AreaId, A693AreaUsuarioId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound102 = 1;
            A10UsuarioNome = T002K21_A10UsuarioNome[0];
            A174UsuarioFuncaoNome = T002K21_A174UsuarioFuncaoNome[0];
            A11UsuarioPerfil = T002K21_A11UsuarioPerfil[0];
            A16UsuarioEmail = T002K21_A16UsuarioEmail[0];
            A14UsuarioAtivo = T002K21_A14UsuarioAtivo[0];
            A9UsuarioId = T002K21_A9UsuarioId[0];
            A173UsuarioFuncaoId = T002K21_A173UsuarioFuncaoId[0];
            n173UsuarioFuncaoId = T002K21_n173UsuarioFuncaoId[0];
            ZM2K102( -20) ;
         }
         pr_default.close(19);
         OnLoadActions2K102( ) ;
      }

      protected void OnLoadActions2K102( )
      {
      }

      protected void CheckExtendedTable2K102( )
      {
         nIsDirty_102 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal2K102( ) ;
         /* Using cursor T002K4 */
         pr_default.execute(2, new Object[] {A9UsuarioId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "USUARIOID_" + sGXsfl_43_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtUsuarioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10UsuarioNome = T002K4_A10UsuarioNome[0];
         A11UsuarioPerfil = T002K4_A11UsuarioPerfil[0];
         A16UsuarioEmail = T002K4_A16UsuarioEmail[0];
         A14UsuarioAtivo = T002K4_A14UsuarioAtivo[0];
         A173UsuarioFuncaoId = T002K4_A173UsuarioFuncaoId[0];
         n173UsuarioFuncaoId = T002K4_n173UsuarioFuncaoId[0];
         pr_default.close(2);
         /* Using cursor T002K5 */
         pr_default.execute(3, new Object[] {n173UsuarioFuncaoId, A173UsuarioFuncaoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A173UsuarioFuncaoId) ) )
            {
               GXCCtl = "USUARIOFUNCAOID_" + sGXsfl_43_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SGUsuario Funcao", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
            }
         }
         A174UsuarioFuncaoNome = T002K5_A174UsuarioFuncaoNome[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors2K102( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable2K102( )
      {
      }

      protected void gxLoad_21( long A9UsuarioId )
      {
         /* Using cursor T002K22 */
         pr_default.execute(20, new Object[] {A9UsuarioId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GXCCtl = "USUARIOID_" + sGXsfl_43_idx;
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtUsuarioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10UsuarioNome = T002K22_A10UsuarioNome[0];
         A11UsuarioPerfil = T002K22_A11UsuarioPerfil[0];
         A16UsuarioEmail = T002K22_A16UsuarioEmail[0];
         A14UsuarioAtivo = T002K22_A14UsuarioAtivo[0];
         A173UsuarioFuncaoId = T002K22_A173UsuarioFuncaoId[0];
         n173UsuarioFuncaoId = T002K22_n173UsuarioFuncaoId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A10UsuarioNome))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuarioPerfil), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A16UsuarioEmail)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A14UsuarioAtivo))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A173UsuarioFuncaoId), 18, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void gxLoad_22( long A173UsuarioFuncaoId )
      {
         /* Using cursor T002K23 */
         pr_default.execute(21, new Object[] {n173UsuarioFuncaoId, A173UsuarioFuncaoId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( (0==A173UsuarioFuncaoId) ) )
            {
               GXCCtl = "USUARIOFUNCAOID_" + sGXsfl_43_idx;
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SGUsuario Funcao", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, GXCCtl);
               AnyError = 1;
            }
         }
         A174UsuarioFuncaoNome = T002K23_A174UsuarioFuncaoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A174UsuarioFuncaoNome))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(21) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(21);
      }

      protected void GetKey2K102( )
      {
         /* Using cursor T002K24 */
         pr_default.execute(22, new Object[] {A689AreaId, A693AreaUsuarioId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound102 = 1;
         }
         else
         {
            RcdFound102 = 0;
         }
         pr_default.close(22);
      }

      protected void getByPrimaryKey2K102( )
      {
         /* Using cursor T002K3 */
         pr_default.execute(1, new Object[] {A689AreaId, A693AreaUsuarioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2K102( 20) ;
            RcdFound102 = 1;
            InitializeNonKey2K102( ) ;
            A693AreaUsuarioId = T002K3_A693AreaUsuarioId[0];
            A9UsuarioId = T002K3_A9UsuarioId[0];
            Z689AreaId = A689AreaId;
            Z693AreaUsuarioId = A693AreaUsuarioId;
            sMode102 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2K102( ) ;
            Gx_mode = sMode102;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound102 = 0;
            InitializeNonKey2K102( ) ;
            sMode102 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal2K102( ) ;
            Gx_mode = sMode102;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes2K102( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency2K102( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002K2 */
            pr_default.execute(0, new Object[] {A689AreaId, A693AreaUsuarioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AreaUsuario"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z9UsuarioId != T002K2_A9UsuarioId[0] ) )
            {
               if ( Z9UsuarioId != T002K2_A9UsuarioId[0] )
               {
                  GXUtil.WriteLog("area:[seudo value changed for attri]"+"UsuarioId");
                  GXUtil.WriteLogRaw("Old: ",Z9UsuarioId);
                  GXUtil.WriteLogRaw("Current: ",T002K2_A9UsuarioId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AreaUsuario"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2K102( )
      {
         BeforeValidate2K102( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2K102( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2K102( 0) ;
            CheckOptimisticConcurrency2K102( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2K102( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2K102( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002K25 */
                     pr_default.execute(23, new Object[] {A689AreaId, A693AreaUsuarioId, A9UsuarioId});
                     pr_default.close(23);
                     pr_default.SmartCacheProvider.SetUpdated("AreaUsuario");
                     if ( (pr_default.getStatus(23) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load2K102( ) ;
            }
            EndLevel2K102( ) ;
         }
         CloseExtendedTableCursors2K102( ) ;
      }

      protected void Update2K102( )
      {
         BeforeValidate2K102( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2K102( ) ;
         }
         if ( ( nIsMod_102 != 0 ) || ( nIsDirty_102 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency2K102( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm2K102( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate2K102( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T002K26 */
                        pr_default.execute(24, new Object[] {A9UsuarioId, A689AreaId, A693AreaUsuarioId});
                        pr_default.close(24);
                        pr_default.SmartCacheProvider.SetUpdated("AreaUsuario");
                        if ( (pr_default.getStatus(24) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AreaUsuario"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate2K102( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey2K102( ) ;
                           }
                        }
                        else
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                           AnyError = 1;
                        }
                     }
                  }
               }
               EndLevel2K102( ) ;
            }
         }
         CloseExtendedTableCursors2K102( ) ;
      }

      protected void DeferredUpdate2K102( )
      {
      }

      protected void Delete2K102( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2K102( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2K102( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2K102( ) ;
            AfterConfirm2K102( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2K102( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002K27 */
                  pr_default.execute(25, new Object[] {A689AreaId, A693AreaUsuarioId});
                  pr_default.close(25);
                  pr_default.SmartCacheProvider.SetUpdated("AreaUsuario");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode102 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2K102( ) ;
         Gx_mode = sMode102;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2K102( )
      {
         standaloneModal2K102( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002K28 */
            pr_default.execute(26, new Object[] {A9UsuarioId});
            A10UsuarioNome = T002K28_A10UsuarioNome[0];
            A11UsuarioPerfil = T002K28_A11UsuarioPerfil[0];
            A16UsuarioEmail = T002K28_A16UsuarioEmail[0];
            A14UsuarioAtivo = T002K28_A14UsuarioAtivo[0];
            A173UsuarioFuncaoId = T002K28_A173UsuarioFuncaoId[0];
            n173UsuarioFuncaoId = T002K28_n173UsuarioFuncaoId[0];
            pr_default.close(26);
            /* Using cursor T002K29 */
            pr_default.execute(27, new Object[] {n173UsuarioFuncaoId, A173UsuarioFuncaoId});
            A174UsuarioFuncaoNome = T002K29_A174UsuarioFuncaoNome[0];
            pr_default.close(27);
         }
      }

      protected void EndLevel2K102( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2K102( )
      {
         /* Scan By routine */
         /* Using cursor T002K30 */
         pr_default.execute(28, new Object[] {A689AreaId});
         RcdFound102 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound102 = 1;
            A693AreaUsuarioId = T002K30_A693AreaUsuarioId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2K102( )
      {
         /* Scan next routine */
         pr_default.readNext(28);
         RcdFound102 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound102 = 1;
            A693AreaUsuarioId = T002K30_A693AreaUsuarioId[0];
         }
      }

      protected void ScanEnd2K102( )
      {
         pr_default.close(28);
      }

      protected void AfterConfirm2K102( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2K102( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2K102( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2K102( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2K102( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2K102( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2K102( )
      {
         edtAreaUsuarioId_Enabled = 0;
         AssignProp("", false, edtAreaUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaUsuarioId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtUsuarioId_Enabled = 0;
         AssignProp("", false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtUsuarioNome_Enabled = 0;
         AssignProp("", false, edtUsuarioNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNome_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         cmbUsuarioPerfil.Enabled = 0;
         AssignProp("", false, cmbUsuarioPerfil_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuarioPerfil.Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtUsuarioFuncaoNome_Enabled = 0;
         AssignProp("", false, edtUsuarioFuncaoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFuncaoNome_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtUsuarioFuncaoId_Enabled = 0;
         AssignProp("", false, edtUsuarioFuncaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFuncaoId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void send_integrity_lvl_hashes2K102( )
      {
      }

      protected void send_integrity_lvl_hashes2K101( )
      {
      }

      protected void SubsflControlProps_43102( )
      {
         edtAreaUsuarioId_Internalname = "AREAUSUARIOID_"+sGXsfl_43_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_43_idx;
         edtUsuarioNome_Internalname = "USUARIONOME_"+sGXsfl_43_idx;
         cmbUsuarioPerfil_Internalname = "USUARIOPERFIL_"+sGXsfl_43_idx;
         edtUsuarioFuncaoNome_Internalname = "USUARIOFUNCAONOME_"+sGXsfl_43_idx;
         edtUsuarioFuncaoId_Internalname = "USUARIOFUNCAOID_"+sGXsfl_43_idx;
      }

      protected void SubsflControlProps_fel_43102( )
      {
         edtAreaUsuarioId_Internalname = "AREAUSUARIOID_"+sGXsfl_43_fel_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_43_fel_idx;
         edtUsuarioNome_Internalname = "USUARIONOME_"+sGXsfl_43_fel_idx;
         cmbUsuarioPerfil_Internalname = "USUARIOPERFIL_"+sGXsfl_43_fel_idx;
         edtUsuarioFuncaoNome_Internalname = "USUARIOFUNCAONOME_"+sGXsfl_43_fel_idx;
         edtUsuarioFuncaoId_Internalname = "USUARIOFUNCAOID_"+sGXsfl_43_fel_idx;
      }

      protected void AddRow2K102( )
      {
         nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_43102( ) ;
         SendRow2K102( ) ;
      }

      protected void SendRow2K102( )
      {
         Gridlevel_usuarioRow = GXWebRow.GetNew(context);
         if ( subGridlevel_usuario_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_usuario_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_usuario_Class, "") != 0 )
            {
               subGridlevel_usuario_Linesclass = subGridlevel_usuario_Class+"Odd";
            }
         }
         else if ( subGridlevel_usuario_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_usuario_Backstyle = 0;
            subGridlevel_usuario_Backcolor = subGridlevel_usuario_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_usuario_Class, "") != 0 )
            {
               subGridlevel_usuario_Linesclass = subGridlevel_usuario_Class+"Uniform";
            }
         }
         else if ( subGridlevel_usuario_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_usuario_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_usuario_Class, "") != 0 )
            {
               subGridlevel_usuario_Linesclass = subGridlevel_usuario_Class+"Odd";
            }
            subGridlevel_usuario_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_usuario_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_usuario_Backstyle = 1;
            if ( ((int)((nGXsfl_43_idx) % (2))) == 0 )
            {
               subGridlevel_usuario_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_usuario_Class, "") != 0 )
               {
                  subGridlevel_usuario_Linesclass = subGridlevel_usuario_Class+"Even";
               }
            }
            else
            {
               subGridlevel_usuario_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_usuario_Class, "") != 0 )
               {
                  subGridlevel_usuario_Linesclass = subGridlevel_usuario_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_usuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAreaUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A693AreaUsuarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtAreaUsuarioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A693AreaUsuarioId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A693AreaUsuarioId), "ZZZZZZZZZZZZZZZZZ9"))),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAreaUsuarioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtAreaUsuarioId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_102_" + sGXsfl_43_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_43_idx + "',43)\"";
         ROClassString = "Attribute";
         Gridlevel_usuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A9UsuarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtUsuarioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A9UsuarioId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A9UsuarioId), "ZZZZZZZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,45);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtUsuarioId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)edtUsuarioId_Horizontalalignment,(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_usuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNome_Internalname,StringUtil.RTrim( A10UsuarioNome),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtUsuarioNome_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         GXCCtl = "USUARIOPERFIL_" + sGXsfl_43_idx;
         cmbUsuarioPerfil.Name = GXCCtl;
         cmbUsuarioPerfil.WebTags = "";
         cmbUsuarioPerfil.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 4, 0)), context.GetMessage( ".", ""), 0);
         cmbUsuarioPerfil.addItem("1", context.GetMessage( "Administrador", ""), 0);
         cmbUsuarioPerfil.addItem("2", context.GetMessage( "Gestor", ""), 0);
         cmbUsuarioPerfil.addItem("3", context.GetMessage( "Coordenador", ""), 0);
         cmbUsuarioPerfil.addItem("4", context.GetMessage( "Técnico", ""), 0);
         cmbUsuarioPerfil.addItem("5", context.GetMessage( "Comercial", ""), 0);
         cmbUsuarioPerfil.addItem("6", context.GetMessage( "Faturamento", ""), 0);
         cmbUsuarioPerfil.addItem("7", context.GetMessage( "Usuário", ""), 0);
         if ( cmbUsuarioPerfil.ItemCount > 0 )
         {
            A11UsuarioPerfil = (short)(Math.Round(NumberUtil.Val( cmbUsuarioPerfil.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A11UsuarioPerfil), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         /* ComboBox */
         Gridlevel_usuarioRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbUsuarioPerfil,(string)cmbUsuarioPerfil_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(A11UsuarioPerfil), 4, 0)),(short)1,(string)cmbUsuarioPerfil_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbUsuarioPerfil.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"TrnColumn",(string)"",(string)"",(string)"",(bool)true,(short)1});
         cmbUsuarioPerfil.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A11UsuarioPerfil), 4, 0));
         AssignProp("", false, cmbUsuarioPerfil_Internalname, "Values", (string)(cmbUsuarioPerfil.ToJavascriptSource()), !bGXsfl_43_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_usuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioFuncaoNome_Internalname,StringUtil.RTrim( A174UsuarioFuncaoNome),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioFuncaoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtUsuarioFuncaoNome_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_usuarioRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioFuncaoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A173UsuarioFuncaoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")),StringUtil.LTrim( ((edtUsuarioFuncaoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A173UsuarioFuncaoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A173UsuarioFuncaoId), "ZZZZZZZZZZZZZZZZZ9"))),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioFuncaoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtUsuarioFuncaoId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)43,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlevel_usuarioRow);
         send_integrity_lvl_hashes2K102( ) ;
         GXCCtl = "Z693AreaUsuarioId_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z693AreaUsuarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "Z9UsuarioId_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9UsuarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdDeleted_102_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_102), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nRcdExists_102_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_102), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "nIsMod_102_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_102), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GXCCtl = "vMODE_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_43_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vAREAID_" + sGXsfl_43_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AreaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "AREAUSUARIOID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAreaUsuarioId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOID_"+sGXsfl_43_idx+"Horizontalalignment", StringUtil.RTrim( edtUsuarioId_Horizontalalignment));
         GxWebStd.gx_hidden_field( context, "USUARIONOME_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioNome_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOPERFIL_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbUsuarioPerfil.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOFUNCAONOME_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioFuncaoNome_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUARIOFUNCAOID_"+sGXsfl_43_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioFuncaoId_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlevel_usuarioContainer.AddRow(Gridlevel_usuarioRow);
      }

      protected void ReadRow2K102( )
      {
         nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_43102( ) ;
         edtAreaUsuarioId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AREAUSUARIOID_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtUsuarioId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOID_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtUsuarioId_Horizontalalignment = cgiGet( "USUARIOID_"+sGXsfl_43_idx+"Horizontalalignment");
         edtUsuarioNome_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIONOME_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         cmbUsuarioPerfil.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOPERFIL_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtUsuarioFuncaoNome_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOFUNCAONOME_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         edtUsuarioFuncaoId_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "USUARIOFUNCAOID_"+sGXsfl_43_idx+"Enabled"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         A693AreaUsuarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAreaUsuarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         if ( ( ( context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
         {
            GXCCtl = "USUARIOID_" + sGXsfl_43_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtUsuarioId_Internalname;
            wbErr = true;
            A9UsuarioId = 0;
         }
         else
         {
            A9UsuarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         }
         A10UsuarioNome = cgiGet( edtUsuarioNome_Internalname);
         cmbUsuarioPerfil.Name = cmbUsuarioPerfil_Internalname;
         cmbUsuarioPerfil.CurrentValue = cgiGet( cmbUsuarioPerfil_Internalname);
         A11UsuarioPerfil = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbUsuarioPerfil_Internalname), "."), 18, MidpointRounding.ToEven));
         A174UsuarioFuncaoNome = cgiGet( edtUsuarioFuncaoNome_Internalname);
         A173UsuarioFuncaoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioFuncaoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         n173UsuarioFuncaoId = false;
         GXCCtl = "Z693AreaUsuarioId_" + sGXsfl_43_idx;
         Z693AreaUsuarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "Z9UsuarioId_" + sGXsfl_43_idx;
         Z9UsuarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdDeleted_102_" + sGXsfl_43_idx;
         nRcdDeleted_102 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_102_" + sGXsfl_43_idx;
         nRcdExists_102 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_102_" + sGXsfl_43_idx;
         nIsMod_102 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtUsuarioFuncaoId_Enabled = edtUsuarioFuncaoId_Enabled;
         defedtUsuarioNome_Enabled = edtUsuarioNome_Enabled;
         defedtAreaUsuarioId_Enabled = edtAreaUsuarioId_Enabled;
      }

      protected void ConfirmValues2K0( )
      {
         nGXsfl_43_idx = 0;
         sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
         SubsflControlProps_43102( ) ;
         while ( nGXsfl_43_idx < nRC_GXsfl_43 )
         {
            nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_43102( ) ;
            ChangePostValue( "Z693AreaUsuarioId_"+sGXsfl_43_idx, cgiGet( "ZT_"+"Z693AreaUsuarioId_"+sGXsfl_43_idx)) ;
            DeletePostValue( "ZT_"+"Z693AreaUsuarioId_"+sGXsfl_43_idx) ;
            ChangePostValue( "Z9UsuarioId_"+sGXsfl_43_idx, cgiGet( "ZT_"+"Z9UsuarioId_"+sGXsfl_43_idx)) ;
            DeletePostValue( "ZT_"+"Z9UsuarioId_"+sGXsfl_43_idx) ;
         }
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 835140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 835140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 835140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("area.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7AreaId,18,0))}, new string[] {"Gx_mode","AreaId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Area");
         forbiddenHiddens.Add("AreaId", context.localUtil.Format( (decimal)(A689AreaId), "ZZZZZZZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("area:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z689AreaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z689AreaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z690AreaNome", StringUtil.RTrim( Z690AreaNome));
         GxWebStd.gx_boolean_hidden_field( context, "Z691AreaAtivo", Z691AreaAtivo);
         GxWebStd.gx_hidden_field( context, "Z692AreaLine", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z692AreaLine), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z746AreaEmail", Z746AreaEmail);
         GxWebStd.gx_hidden_field( context, "Z1EmpresaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EmpresaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "O692AreaLine", StringUtil.LTrim( StringUtil.NToC( (decimal)(O692AreaLine), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_43", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_43_idx), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "N1EmpresaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EmpresaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUSUARIOID_DATA", AV17UsuarioId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUSUARIOID_DATA", AV17UsuarioId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vAREAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AreaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAREAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7AreaId), "ZZZZZZZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_EMPRESAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_EmpresaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vEMPRESAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15EmpresaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV21Pgmname));
         GxWebStd.gx_hidden_field( context, "USUARIOEMAIL", A16UsuarioEmail);
         GxWebStd.gx_boolean_hidden_field( context, "USUARIOATIVO", A14UsuarioAtivo);
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Objectcall", StringUtil.RTrim( Gxuitabspanel_tabs1_Objectcall));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Enabled", StringUtil.BoolToStr( Gxuitabspanel_tabs1_Enabled));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Class", StringUtil.RTrim( Gxuitabspanel_tabs1_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS1_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs1_Historymanagement));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIOID_Objectcall", StringUtil.RTrim( Combo_usuarioid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIOID_Cls", StringUtil.RTrim( Combo_usuarioid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIOID_Enabled", StringUtil.BoolToStr( Combo_usuarioid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIOID_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_usuarioid_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIOID_Isgriditem", StringUtil.BoolToStr( Combo_usuarioid_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_USUARIOID_Emptyitemtext", StringUtil.RTrim( Combo_usuarioid_Emptyitemtext));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         context.WriteHtmlText( "<script type=\"text/javascript\">") ;
         context.WriteHtmlText( "gx.setLanguageCode(\""+context.GetLanguageProperty( "code")+"\");") ;
         if ( ! context.isSpaRequest( ) )
         {
            context.WriteHtmlText( "gx.setDateFormat(\""+context.GetLanguageProperty( "date_fmt")+"\");") ;
            context.WriteHtmlText( "gx.setTimeFormat("+context.GetLanguageProperty( "time_fmt")+");") ;
            context.WriteHtmlText( "gx.setCenturyFirstYear("+40+");") ;
            context.WriteHtmlText( "gx.setDecimalPoint(\""+context.GetLanguageProperty( "decimal_point")+"\");") ;
            context.WriteHtmlText( "gx.setThousandSeparator(\""+context.GetLanguageProperty( "thousand_sep")+"\");") ;
            context.WriteHtmlText( "gx.StorageTimeZone = "+2+";") ;
         }
         context.WriteHtmlText( "</script>") ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("area.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7AreaId,18,0))}, new string[] {"Gx_mode","AreaId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Area" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Área", "") ;
      }

      protected void InitializeNonKey2K101( )
      {
         A690AreaNome = "";
         AssignAttri("", false, "A690AreaNome", A690AreaNome);
         A692AreaLine = 0;
         AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
         A746AreaEmail = "";
         AssignAttri("", false, "A746AreaEmail", A746AreaEmail);
         A2EmpresaNome = "";
         AssignAttri("", false, "A2EmpresaNome", A2EmpresaNome);
         A1EmpresaId = AV15EmpresaId;
         AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 18, 0));
         A691AreaAtivo = true;
         AssignAttri("", false, "A691AreaAtivo", A691AreaAtivo);
         O692AreaLine = A692AreaLine;
         AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
         Z690AreaNome = "";
         Z691AreaAtivo = false;
         Z692AreaLine = 0;
         Z746AreaEmail = "";
         Z1EmpresaId = 0;
      }

      protected void InitAll2K101( )
      {
         A689AreaId = 0;
         AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
         InitializeNonKey2K101( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1EmpresaId = i1EmpresaId;
         AssignAttri("", false, "A1EmpresaId", StringUtil.LTrimStr( (decimal)(A1EmpresaId), 18, 0));
         A691AreaAtivo = i691AreaAtivo;
         AssignAttri("", false, "A691AreaAtivo", A691AreaAtivo);
      }

      protected void InitializeNonKey2K102( )
      {
         A9UsuarioId = 0;
         A10UsuarioNome = "";
         A173UsuarioFuncaoId = 0;
         n173UsuarioFuncaoId = false;
         A174UsuarioFuncaoNome = "";
         A11UsuarioPerfil = 0;
         A16UsuarioEmail = "";
         AssignAttri("", false, "A16UsuarioEmail", A16UsuarioEmail);
         A14UsuarioAtivo = false;
         AssignAttri("", false, "A14UsuarioAtivo", A14UsuarioAtivo);
         Z9UsuarioId = 0;
      }

      protected void InitAll2K102( )
      {
         A693AreaUsuarioId = 0;
         InitializeNonKey2K102( ) ;
      }

      protected void StandaloneModalInsert2K102( )
      {
         A692AreaLine = i692AreaLine;
         AssignAttri("", false, "A692AreaLine", StringUtil.LTrimStr( (decimal)(A692AreaLine), 4, 0));
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202461819381216", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages."+StringUtil.Lower( context.GetLanguageProperty( "code"))+".js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 835140), false, true);
         context.AddJavascriptSource("area.js", "?202461819381217", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties102( )
      {
         edtUsuarioFuncaoId_Enabled = defedtUsuarioFuncaoId_Enabled;
         AssignProp("", false, edtUsuarioFuncaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFuncaoId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtUsuarioNome_Enabled = defedtUsuarioNome_Enabled;
         AssignProp("", false, edtUsuarioNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNome_Enabled), 5, 0), !bGXsfl_43_Refreshing);
         edtAreaUsuarioId_Enabled = defedtAreaUsuarioId_Enabled;
         AssignProp("", false, edtAreaUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaUsuarioId_Enabled), 5, 0), !bGXsfl_43_Refreshing);
      }

      protected void StartGridControl43( )
      {
         Gridlevel_usuarioContainer.AddObjectProperty("GridName", "Gridlevel_usuario");
         Gridlevel_usuarioContainer.AddObjectProperty("Header", subGridlevel_usuario_Header);
         Gridlevel_usuarioContainer.AddObjectProperty("Class", "GridNoBorder WorkWith");
         Gridlevel_usuarioContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_usuarioContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_usuarioContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_usuario_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_usuarioContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_usuarioContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_usuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_usuarioColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A693AreaUsuarioId), 18, 0, ".", ""))));
         Gridlevel_usuarioColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtAreaUsuarioId_Enabled), 5, 0, ".", "")));
         Gridlevel_usuarioContainer.AddColumnProperties(Gridlevel_usuarioColumn);
         Gridlevel_usuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_usuarioColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A9UsuarioId), 18, 0, ".", ""))));
         Gridlevel_usuarioColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioId_Enabled), 5, 0, ".", "")));
         Gridlevel_usuarioColumn.AddObjectProperty("Horizontalalignment", StringUtil.RTrim( edtUsuarioId_Horizontalalignment));
         Gridlevel_usuarioContainer.AddColumnProperties(Gridlevel_usuarioColumn);
         Gridlevel_usuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_usuarioColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A10UsuarioNome)));
         Gridlevel_usuarioColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioNome_Enabled), 5, 0, ".", "")));
         Gridlevel_usuarioContainer.AddColumnProperties(Gridlevel_usuarioColumn);
         Gridlevel_usuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_usuarioColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuarioPerfil), 4, 0, ".", ""))));
         Gridlevel_usuarioColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbUsuarioPerfil.Enabled), 5, 0, ".", "")));
         Gridlevel_usuarioContainer.AddColumnProperties(Gridlevel_usuarioColumn);
         Gridlevel_usuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_usuarioColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A174UsuarioFuncaoNome)));
         Gridlevel_usuarioColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioFuncaoNome_Enabled), 5, 0, ".", "")));
         Gridlevel_usuarioContainer.AddColumnProperties(Gridlevel_usuarioColumn);
         Gridlevel_usuarioColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_usuarioColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A173UsuarioFuncaoId), 18, 0, ".", ""))));
         Gridlevel_usuarioColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioFuncaoId_Enabled), 5, 0, ".", "")));
         Gridlevel_usuarioContainer.AddColumnProperties(Gridlevel_usuarioColumn);
         Gridlevel_usuarioContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_usuario_Selectedindex), 4, 0, ".", "")));
         Gridlevel_usuarioContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_usuario_Allowselection), 1, 0, ".", "")));
         Gridlevel_usuarioContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_usuario_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_usuarioContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_usuario_Allowhovering), 1, 0, ".", "")));
         Gridlevel_usuarioContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_usuario_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_usuarioContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_usuario_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_usuarioContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_usuario_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTab1_title_Internalname = "TAB1_TITLE";
         edtAreaNome_Internalname = "AREANOME";
         edtAreaEmail_Internalname = "AREAEMAIL";
         chkAreaAtivo_Internalname = "AREAATIVO";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         lblTab2_title_Internalname = "TAB2_TITLE";
         edtAreaUsuarioId_Internalname = "AREAUSUARIOID";
         edtUsuarioId_Internalname = "USUARIOID";
         edtUsuarioNome_Internalname = "USUARIONOME";
         cmbUsuarioPerfil_Internalname = "USUARIOPERFIL";
         edtUsuarioFuncaoNome_Internalname = "USUARIOFUNCAONOME";
         edtUsuarioFuncaoId_Internalname = "USUARIOFUNCAOID";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabs1_Internalname = "GXUITABSPANEL_TABS1";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Combo_usuarioid_Internalname = "COMBO_USUARIOID";
         edtAreaId_Internalname = "AREAID";
         edtAreaLine_Internalname = "AREALINE";
         edtEmpresaId_Internalname = "EMPRESAID";
         edtEmpresaNome_Internalname = "EMPRESANOME";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_usuario_Internalname = "GRIDLEVEL_USUARIO";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme", false);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_usuario_Allowcollapsing = 0;
         subGridlevel_usuario_Allowselection = 0;
         subGridlevel_usuario_Header = "";
         Combo_usuarioid_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Área", "");
         edtUsuarioFuncaoId_Jsonclick = "";
         edtUsuarioFuncaoNome_Jsonclick = "";
         cmbUsuarioPerfil_Jsonclick = "";
         edtUsuarioNome_Jsonclick = "";
         edtUsuarioId_Jsonclick = "";
         edtAreaUsuarioId_Jsonclick = "";
         subGridlevel_usuario_Class = "GridNoBorder WorkWith";
         subGridlevel_usuario_Backcolorstyle = 0;
         Combo_usuarioid_Titlecontrolidtoreplace = "";
         edtUsuarioFuncaoId_Enabled = 0;
         edtUsuarioFuncaoNome_Enabled = 0;
         cmbUsuarioPerfil.Enabled = 0;
         edtUsuarioNome_Enabled = 0;
         edtUsuarioId_Enabled = 1;
         edtAreaUsuarioId_Enabled = 0;
         edtEmpresaNome_Jsonclick = "";
         edtEmpresaNome_Enabled = 0;
         edtEmpresaNome_Visible = 1;
         edtEmpresaId_Jsonclick = "";
         edtEmpresaId_Enabled = 1;
         edtEmpresaId_Visible = 1;
         edtAreaLine_Jsonclick = "";
         edtAreaLine_Enabled = 0;
         edtAreaLine_Visible = 1;
         edtAreaId_Jsonclick = "";
         edtAreaId_Enabled = 0;
         edtAreaId_Visible = 1;
         Combo_usuarioid_Emptyitemtext = "(Selecionar)";
         Combo_usuarioid_Isgriditem = Convert.ToBoolean( -1);
         Combo_usuarioid_Cls = "ExtendedCombo";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         chkAreaAtivo.Enabled = 1;
         edtAreaEmail_Jsonclick = "";
         edtAreaEmail_Enabled = 1;
         edtAreaNome_Jsonclick = "";
         edtAreaNome_Enabled = 1;
         Gxuitabspanel_tabs1_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs1_Class = "Tab";
         Gxuitabspanel_tabs1_Pagecount = 2;
         edtUsuarioId_Horizontalalignment = "end";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridlevel_usuario_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_43102( ) ;
         while ( nGXsfl_43_idx <= nRC_GXsfl_43 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal2K102( ) ;
            standaloneModal2K102( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow2K102( ) ;
            nGXsfl_43_idx = (int)(nGXsfl_43_idx+1);
            sGXsfl_43_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_43_idx), 4, 0), 4, "0");
            SubsflControlProps_43102( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_usuarioContainer)) ;
         /* End function gxnrGridlevel_usuario_newrow */
      }

      protected void init_web_controls( )
      {
         chkAreaAtivo.Name = "AREAATIVO";
         chkAreaAtivo.WebTags = "";
         chkAreaAtivo.Caption = context.GetMessage( "Ativo", "");
         AssignProp("", false, chkAreaAtivo_Internalname, "TitleCaption", chkAreaAtivo.Caption, true);
         chkAreaAtivo.CheckedValue = "false";
         if ( IsIns( ) && (false==A691AreaAtivo) )
         {
            A691AreaAtivo = true;
            AssignAttri("", false, "A691AreaAtivo", A691AreaAtivo);
         }
         GXCCtl = "USUARIOPERFIL_" + sGXsfl_43_idx;
         cmbUsuarioPerfil.Name = GXCCtl;
         cmbUsuarioPerfil.WebTags = "";
         cmbUsuarioPerfil.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 4, 0)), context.GetMessage( ".", ""), 0);
         cmbUsuarioPerfil.addItem("1", context.GetMessage( "Administrador", ""), 0);
         cmbUsuarioPerfil.addItem("2", context.GetMessage( "Gestor", ""), 0);
         cmbUsuarioPerfil.addItem("3", context.GetMessage( "Coordenador", ""), 0);
         cmbUsuarioPerfil.addItem("4", context.GetMessage( "Técnico", ""), 0);
         cmbUsuarioPerfil.addItem("5", context.GetMessage( "Comercial", ""), 0);
         cmbUsuarioPerfil.addItem("6", context.GetMessage( "Faturamento", ""), 0);
         cmbUsuarioPerfil.addItem("7", context.GetMessage( "Usuário", ""), 0);
         if ( cmbUsuarioPerfil.ItemCount > 0 )
         {
            A11UsuarioPerfil = (short)(Math.Round(NumberUtil.Val( cmbUsuarioPerfil.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A11UsuarioPerfil), 4, 0))), "."), 18, MidpointRounding.ToEven));
         }
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Empresaid( )
      {
         /* Using cursor T002K17 */
         pr_default.execute(15, new Object[] {A1EmpresaId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Empresa", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "EMPRESAID");
            AnyError = 1;
            GX_FocusControl = edtEmpresaId_Internalname;
         }
         A2EmpresaNome = T002K17_A2EmpresaNome[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2EmpresaNome", StringUtil.RTrim( A2EmpresaNome));
      }

      public void Valid_Usuarioid( )
      {
         n173UsuarioFuncaoId = false;
         A11UsuarioPerfil = (short)(Math.Round(NumberUtil.Val( cmbUsuarioPerfil.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbUsuarioPerfil.CurrentValue = StringUtil.LTrimStr( (decimal)(A11UsuarioPerfil), 4, 0);
         /* Using cursor T002K28 */
         pr_default.execute(26, new Object[] {A9UsuarioId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioId_Internalname;
         }
         A10UsuarioNome = T002K28_A10UsuarioNome[0];
         A11UsuarioPerfil = T002K28_A11UsuarioPerfil[0];
         cmbUsuarioPerfil.CurrentValue = StringUtil.LTrimStr( (decimal)(A11UsuarioPerfil), 4, 0);
         A16UsuarioEmail = T002K28_A16UsuarioEmail[0];
         A14UsuarioAtivo = T002K28_A14UsuarioAtivo[0];
         A173UsuarioFuncaoId = T002K28_A173UsuarioFuncaoId[0];
         n173UsuarioFuncaoId = T002K28_n173UsuarioFuncaoId[0];
         pr_default.close(26);
         /* Using cursor T002K29 */
         pr_default.execute(27, new Object[] {n173UsuarioFuncaoId, A173UsuarioFuncaoId});
         if ( (pr_default.getStatus(27) == 101) )
         {
            if ( ! ( (0==A173UsuarioFuncaoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SGUsuario Funcao", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOFUNCAOID");
               AnyError = 1;
            }
         }
         A174UsuarioFuncaoNome = T002K29_A174UsuarioFuncaoNome[0];
         pr_default.close(27);
         dynload_actions( ) ;
         if ( cmbUsuarioPerfil.ItemCount > 0 )
         {
            A11UsuarioPerfil = (short)(Math.Round(NumberUtil.Val( cmbUsuarioPerfil.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A11UsuarioPerfil), 4, 0))), "."), 18, MidpointRounding.ToEven));
            cmbUsuarioPerfil.CurrentValue = StringUtil.LTrimStr( (decimal)(A11UsuarioPerfil), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioPerfil.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A11UsuarioPerfil), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A10UsuarioNome", StringUtil.RTrim( A10UsuarioNome));
         AssignAttri("", false, "A11UsuarioPerfil", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuarioPerfil), 4, 0, ".", "")));
         cmbUsuarioPerfil.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A11UsuarioPerfil), 4, 0));
         AssignProp("", false, cmbUsuarioPerfil_Internalname, "Values", cmbUsuarioPerfil.ToJavascriptSource(), true);
         AssignAttri("", false, "A16UsuarioEmail", A16UsuarioEmail);
         AssignAttri("", false, "A14UsuarioAtivo", A14UsuarioAtivo);
         AssignAttri("", false, "A173UsuarioFuncaoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A173UsuarioFuncaoId), 18, 0, ".", "")));
         AssignAttri("", false, "A174UsuarioFuncaoNome", StringUtil.RTrim( A174UsuarioFuncaoNome));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7AreaId',fld:'vAREAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true},{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7AreaId',fld:'vAREAID',pic:'ZZZZZZZZZZZZZZZZZ9',hsh:true},{av:'A689AreaId',fld:'AREAID',pic:'ZZZZZZZZZZZZZZZZZ9'},{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E122K2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]}");
         setEventMetadata("VALID_AREANOME","{handler:'Valid_Areanome',iparms:[{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]");
         setEventMetadata("VALID_AREANOME",",oparms:[{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]}");
         setEventMetadata("VALID_AREAEMAIL","{handler:'Valid_Areaemail',iparms:[{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]");
         setEventMetadata("VALID_AREAEMAIL",",oparms:[{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]}");
         setEventMetadata("VALID_AREAID","{handler:'Valid_Areaid',iparms:[{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]");
         setEventMetadata("VALID_AREAID",",oparms:[{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]}");
         setEventMetadata("VALID_AREALINE","{handler:'Valid_Arealine',iparms:[{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]");
         setEventMetadata("VALID_AREALINE",",oparms:[{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]}");
         setEventMetadata("VALID_EMPRESAID","{handler:'Valid_Empresaid',iparms:[{av:'A1EmpresaId',fld:'EMPRESAID',pic:'ZZZZZZZZZZZZZZZZZ9'},{av:'A2EmpresaNome',fld:'EMPRESANOME',pic:''},{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]");
         setEventMetadata("VALID_EMPRESAID",",oparms:[{av:'A2EmpresaNome',fld:'EMPRESANOME',pic:''},{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]}");
         setEventMetadata("VALID_AREAUSUARIOID","{handler:'Valid_Areausuarioid',iparms:[{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]");
         setEventMetadata("VALID_AREAUSUARIOID",",oparms:[{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[{av:'A9UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZZZZZZZZZ9'},{av:'A173UsuarioFuncaoId',fld:'USUARIOFUNCAOID',pic:'ZZZZZZZZZZZZZZZZZ9'},{av:'A10UsuarioNome',fld:'USUARIONOME',pic:''},{av:'cmbUsuarioPerfil'},{av:'A11UsuarioPerfil',fld:'USUARIOPERFIL',pic:'ZZZ9'},{av:'A16UsuarioEmail',fld:'USUARIOEMAIL',pic:''},{av:'A14UsuarioAtivo',fld:'USUARIOATIVO',pic:''},{av:'A174UsuarioFuncaoNome',fld:'USUARIOFUNCAONOME',pic:''},{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]");
         setEventMetadata("VALID_USUARIOID",",oparms:[{av:'A10UsuarioNome',fld:'USUARIONOME',pic:''},{av:'cmbUsuarioPerfil'},{av:'A11UsuarioPerfil',fld:'USUARIOPERFIL',pic:'ZZZ9'},{av:'A16UsuarioEmail',fld:'USUARIOEMAIL',pic:''},{av:'A14UsuarioAtivo',fld:'USUARIOATIVO',pic:''},{av:'A173UsuarioFuncaoId',fld:'USUARIOFUNCAOID',pic:'ZZZZZZZZZZZZZZZZZ9'},{av:'A174UsuarioFuncaoNome',fld:'USUARIOFUNCAONOME',pic:''},{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]}");
         setEventMetadata("VALID_USUARIOFUNCAOID","{handler:'Valid_Usuariofuncaoid',iparms:[{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]");
         setEventMetadata("VALID_USUARIOFUNCAOID",",oparms:[{av:'A691AreaAtivo',fld:'AREAATIVO',pic:''}]}");
         return  ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected override void CloseCursors( )
      {
         pr_default.close(1);
         pr_default.close(26);
         pr_default.close(27);
         pr_default.close(5);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z690AreaNome = "";
         Z746AreaEmail = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs1 = new GXUserControl();
         lblTab1_title_Jsonclick = "";
         TempTags = "";
         A690AreaNome = "";
         A746AreaEmail = "";
         lblTab2_title_Jsonclick = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         ucCombo_usuarioid = new GXUserControl();
         Combo_usuarioid_Caption = "";
         AV17UsuarioId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A2EmpresaNome = "";
         Gridlevel_usuarioContainer = new GXWebGrid( context);
         sMode102 = "";
         sStyleString = "";
         AV21Pgmname = "";
         A16UsuarioEmail = "";
         Gxuitabspanel_tabs1_Objectcall = "";
         Gxuitabspanel_tabs1_Activepagecontrolname = "";
         Combo_usuarioid_Objectcall = "";
         Combo_usuarioid_Class = "";
         Combo_usuarioid_Icontype = "";
         Combo_usuarioid_Icon = "";
         Combo_usuarioid_Tooltip = "";
         Combo_usuarioid_Selectedvalue_set = "";
         Combo_usuarioid_Selectedvalue_get = "";
         Combo_usuarioid_Selectedtext_set = "";
         Combo_usuarioid_Selectedtext_get = "";
         Combo_usuarioid_Gamoauthtoken = "";
         Combo_usuarioid_Ddointernalname = "";
         Combo_usuarioid_Titlecontrolalign = "";
         Combo_usuarioid_Dropdownoptionstype = "";
         Combo_usuarioid_Datalisttype = "";
         Combo_usuarioid_Datalistfixedvalues = "";
         Combo_usuarioid_Datalistproc = "";
         Combo_usuarioid_Datalistprocparametersprefix = "";
         Combo_usuarioid_Remoteservicesparameters = "";
         Combo_usuarioid_Htmltemplate = "";
         Combo_usuarioid_Multiplevaluestype = "";
         Combo_usuarioid_Loadingdata = "";
         Combo_usuarioid_Noresultsfound = "";
         Combo_usuarioid_Onlyselectedvalues = "";
         Combo_usuarioid_Selectalltext = "";
         Combo_usuarioid_Multiplevaluesseparator = "";
         Combo_usuarioid_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode101 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A10UsuarioNome = "";
         A174UsuarioFuncaoNome = "";
         AV16SDTContexto = new SdtSDTContexto(context);
         AV12WebSession = context.GetSession();
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         GXt_objcol_SdtDVB_SDTComboData_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV18ComboSelectedValue = "";
         Z2EmpresaNome = "";
         T002K8_A2EmpresaNome = new string[] {""} ;
         T002K9_A689AreaId = new long[1] ;
         T002K9_A690AreaNome = new string[] {""} ;
         T002K9_A691AreaAtivo = new bool[] {false} ;
         T002K9_A692AreaLine = new short[1] ;
         T002K9_A746AreaEmail = new string[] {""} ;
         T002K9_A2EmpresaNome = new string[] {""} ;
         T002K9_A1EmpresaId = new long[1] ;
         T002K10_A2EmpresaNome = new string[] {""} ;
         T002K11_A689AreaId = new long[1] ;
         T002K7_A689AreaId = new long[1] ;
         T002K7_A690AreaNome = new string[] {""} ;
         T002K7_A691AreaAtivo = new bool[] {false} ;
         T002K7_A692AreaLine = new short[1] ;
         T002K7_A746AreaEmail = new string[] {""} ;
         T002K7_A1EmpresaId = new long[1] ;
         T002K12_A689AreaId = new long[1] ;
         T002K13_A689AreaId = new long[1] ;
         T002K6_A689AreaId = new long[1] ;
         T002K6_A690AreaNome = new string[] {""} ;
         T002K6_A691AreaAtivo = new bool[] {false} ;
         T002K6_A692AreaLine = new short[1] ;
         T002K6_A746AreaEmail = new string[] {""} ;
         T002K6_A1EmpresaId = new long[1] ;
         T002K14_A689AreaId = new long[1] ;
         T002K17_A2EmpresaNome = new string[] {""} ;
         T002K18_A702DocumentoId = new long[1] ;
         T002K20_A689AreaId = new long[1] ;
         Z10UsuarioNome = "";
         Z16UsuarioEmail = "";
         Z174UsuarioFuncaoNome = "";
         T002K21_A689AreaId = new long[1] ;
         T002K21_A693AreaUsuarioId = new long[1] ;
         T002K21_A10UsuarioNome = new string[] {""} ;
         T002K21_A174UsuarioFuncaoNome = new string[] {""} ;
         T002K21_A11UsuarioPerfil = new short[1] ;
         T002K21_A16UsuarioEmail = new string[] {""} ;
         T002K21_A14UsuarioAtivo = new bool[] {false} ;
         T002K21_A9UsuarioId = new long[1] ;
         T002K21_A173UsuarioFuncaoId = new long[1] ;
         T002K21_n173UsuarioFuncaoId = new bool[] {false} ;
         T002K4_A10UsuarioNome = new string[] {""} ;
         T002K4_A11UsuarioPerfil = new short[1] ;
         T002K4_A16UsuarioEmail = new string[] {""} ;
         T002K4_A14UsuarioAtivo = new bool[] {false} ;
         T002K4_A173UsuarioFuncaoId = new long[1] ;
         T002K4_n173UsuarioFuncaoId = new bool[] {false} ;
         GXCCtl = "";
         T002K5_A174UsuarioFuncaoNome = new string[] {""} ;
         T002K22_A10UsuarioNome = new string[] {""} ;
         T002K22_A11UsuarioPerfil = new short[1] ;
         T002K22_A16UsuarioEmail = new string[] {""} ;
         T002K22_A14UsuarioAtivo = new bool[] {false} ;
         T002K22_A173UsuarioFuncaoId = new long[1] ;
         T002K22_n173UsuarioFuncaoId = new bool[] {false} ;
         T002K23_A174UsuarioFuncaoNome = new string[] {""} ;
         T002K24_A689AreaId = new long[1] ;
         T002K24_A693AreaUsuarioId = new long[1] ;
         T002K3_A689AreaId = new long[1] ;
         T002K3_A693AreaUsuarioId = new long[1] ;
         T002K3_A9UsuarioId = new long[1] ;
         T002K2_A689AreaId = new long[1] ;
         T002K2_A693AreaUsuarioId = new long[1] ;
         T002K2_A9UsuarioId = new long[1] ;
         T002K28_A10UsuarioNome = new string[] {""} ;
         T002K28_A11UsuarioPerfil = new short[1] ;
         T002K28_A16UsuarioEmail = new string[] {""} ;
         T002K28_A14UsuarioAtivo = new bool[] {false} ;
         T002K28_A173UsuarioFuncaoId = new long[1] ;
         T002K28_n173UsuarioFuncaoId = new bool[] {false} ;
         T002K29_A174UsuarioFuncaoNome = new string[] {""} ;
         T002K30_A689AreaId = new long[1] ;
         T002K30_A693AreaUsuarioId = new long[1] ;
         Gridlevel_usuarioRow = new GXWebRow();
         subGridlevel_usuario_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlevel_usuarioColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.area__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.area__default(),
            new Object[][] {
                new Object[] {
               T002K2_A689AreaId, T002K2_A693AreaUsuarioId, T002K2_A9UsuarioId
               }
               , new Object[] {
               T002K3_A689AreaId, T002K3_A693AreaUsuarioId, T002K3_A9UsuarioId
               }
               , new Object[] {
               T002K4_A10UsuarioNome, T002K4_A11UsuarioPerfil, T002K4_A16UsuarioEmail, T002K4_A14UsuarioAtivo, T002K4_A173UsuarioFuncaoId, T002K4_n173UsuarioFuncaoId
               }
               , new Object[] {
               T002K5_A174UsuarioFuncaoNome
               }
               , new Object[] {
               T002K6_A689AreaId, T002K6_A690AreaNome, T002K6_A691AreaAtivo, T002K6_A692AreaLine, T002K6_A746AreaEmail, T002K6_A1EmpresaId
               }
               , new Object[] {
               T002K7_A689AreaId, T002K7_A690AreaNome, T002K7_A691AreaAtivo, T002K7_A692AreaLine, T002K7_A746AreaEmail, T002K7_A1EmpresaId
               }
               , new Object[] {
               T002K8_A2EmpresaNome
               }
               , new Object[] {
               T002K9_A689AreaId, T002K9_A690AreaNome, T002K9_A691AreaAtivo, T002K9_A692AreaLine, T002K9_A746AreaEmail, T002K9_A2EmpresaNome, T002K9_A1EmpresaId
               }
               , new Object[] {
               T002K10_A2EmpresaNome
               }
               , new Object[] {
               T002K11_A689AreaId
               }
               , new Object[] {
               T002K12_A689AreaId
               }
               , new Object[] {
               T002K13_A689AreaId
               }
               , new Object[] {
               T002K14_A689AreaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002K17_A2EmpresaNome
               }
               , new Object[] {
               T002K18_A702DocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               T002K20_A689AreaId
               }
               , new Object[] {
               T002K21_A689AreaId, T002K21_A693AreaUsuarioId, T002K21_A10UsuarioNome, T002K21_A174UsuarioFuncaoNome, T002K21_A11UsuarioPerfil, T002K21_A16UsuarioEmail, T002K21_A14UsuarioAtivo, T002K21_A9UsuarioId, T002K21_A173UsuarioFuncaoId, T002K21_n173UsuarioFuncaoId
               }
               , new Object[] {
               T002K22_A10UsuarioNome, T002K22_A11UsuarioPerfil, T002K22_A16UsuarioEmail, T002K22_A14UsuarioAtivo, T002K22_A173UsuarioFuncaoId, T002K22_n173UsuarioFuncaoId
               }
               , new Object[] {
               T002K23_A174UsuarioFuncaoNome
               }
               , new Object[] {
               T002K24_A689AreaId, T002K24_A693AreaUsuarioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002K28_A10UsuarioNome, T002K28_A11UsuarioPerfil, T002K28_A16UsuarioEmail, T002K28_A14UsuarioAtivo, T002K28_A173UsuarioFuncaoId, T002K28_n173UsuarioFuncaoId
               }
               , new Object[] {
               T002K29_A174UsuarioFuncaoNome
               }
               , new Object[] {
               T002K30_A689AreaId, T002K30_A693AreaUsuarioId
               }
            }
         );
         AV21Pgmname = "Area";
         Z1EmpresaId = 0;
         N1EmpresaId = 0;
         i1EmpresaId = 0;
         A1EmpresaId = 0;
         Z691AreaAtivo = true;
         A691AreaAtivo = true;
         i691AreaAtivo = true;
      }

      private short Z692AreaLine ;
      private short O692AreaLine ;
      private short nRcdDeleted_102 ;
      private short nRcdExists_102 ;
      private short nIsMod_102 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A692AreaLine ;
      private short Gx_BScreen ;
      private short nBlankRcdCount102 ;
      private short RcdFound102 ;
      private short B692AreaLine ;
      private short nBlankRcdUsr102 ;
      private short RcdFound101 ;
      private short s692AreaLine ;
      private short A11UsuarioPerfil ;
      private short Z11UsuarioPerfil ;
      private short nIsDirty_102 ;
      private short subGridlevel_usuario_Backcolorstyle ;
      private short subGridlevel_usuario_Backstyle ;
      private short gxajaxcallmode ;
      private short i692AreaLine ;
      private short subGridlevel_usuario_Allowselection ;
      private short subGridlevel_usuario_Allowhovering ;
      private short subGridlevel_usuario_Allowcollapsing ;
      private short subGridlevel_usuario_Collapsed ;
      private int nRC_GXsfl_43 ;
      private int nGXsfl_43_idx=1 ;
      private int trnEnded ;
      private int Gxuitabspanel_tabs1_Pagecount ;
      private int edtAreaNome_Enabled ;
      private int edtAreaEmail_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtAreaId_Enabled ;
      private int edtAreaId_Visible ;
      private int edtAreaLine_Enabled ;
      private int edtAreaLine_Visible ;
      private int edtEmpresaId_Visible ;
      private int edtEmpresaId_Enabled ;
      private int edtEmpresaNome_Visible ;
      private int edtEmpresaNome_Enabled ;
      private int edtAreaUsuarioId_Enabled ;
      private int edtUsuarioId_Enabled ;
      private int edtUsuarioNome_Enabled ;
      private int edtUsuarioFuncaoNome_Enabled ;
      private int edtUsuarioFuncaoId_Enabled ;
      private int fRowAdded ;
      private int Gxuitabspanel_tabs1_Activepage ;
      private int Combo_usuarioid_Datalistupdateminimumcharacters ;
      private int Combo_usuarioid_Gxcontroltype ;
      private int AV22GXV1 ;
      private int subGridlevel_usuario_Backcolor ;
      private int subGridlevel_usuario_Allbackcolor ;
      private int defedtUsuarioFuncaoId_Enabled ;
      private int defedtUsuarioNome_Enabled ;
      private int defedtAreaUsuarioId_Enabled ;
      private int idxLst ;
      private int subGridlevel_usuario_Selectedindex ;
      private int subGridlevel_usuario_Selectioncolor ;
      private int subGridlevel_usuario_Hoveringcolor ;
      private long wcpOAV7AreaId ;
      private long Z689AreaId ;
      private long Z1EmpresaId ;
      private long N1EmpresaId ;
      private long Z693AreaUsuarioId ;
      private long Z9UsuarioId ;
      private long A1EmpresaId ;
      private long A9UsuarioId ;
      private long A173UsuarioFuncaoId ;
      private long AV7AreaId ;
      private long A689AreaId ;
      private long AV13Insert_EmpresaId ;
      private long AV15EmpresaId ;
      private long GRIDLEVEL_USUARIO_nFirstRecordOnPage ;
      private long A693AreaUsuarioId ;
      private long Z173UsuarioFuncaoId ;
      private long i1EmpresaId ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z690AreaNome ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAreaNome_Internalname ;
      private string sGXsfl_43_idx="0001" ;
      private string edtUsuarioId_Horizontalalignment ;
      private string edtUsuarioId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Gxuitabspanel_tabs1_Class ;
      private string Gxuitabspanel_tabs1_Internalname ;
      private string lblTab1_title_Internalname ;
      private string lblTab1_title_Jsonclick ;
      private string divUnnamedtable2_Internalname ;
      private string TempTags ;
      private string A690AreaNome ;
      private string edtAreaNome_Jsonclick ;
      private string edtAreaEmail_Internalname ;
      private string edtAreaEmail_Jsonclick ;
      private string chkAreaAtivo_Internalname ;
      private string lblTab2_title_Internalname ;
      private string lblTab2_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Combo_usuarioid_Caption ;
      private string Combo_usuarioid_Cls ;
      private string Combo_usuarioid_Emptyitemtext ;
      private string Combo_usuarioid_Internalname ;
      private string edtAreaId_Internalname ;
      private string edtAreaId_Jsonclick ;
      private string edtAreaLine_Internalname ;
      private string edtAreaLine_Jsonclick ;
      private string edtEmpresaId_Internalname ;
      private string edtEmpresaId_Jsonclick ;
      private string edtEmpresaNome_Internalname ;
      private string A2EmpresaNome ;
      private string edtEmpresaNome_Jsonclick ;
      private string sMode102 ;
      private string edtAreaUsuarioId_Internalname ;
      private string edtUsuarioNome_Internalname ;
      private string cmbUsuarioPerfil_Internalname ;
      private string edtUsuarioFuncaoNome_Internalname ;
      private string edtUsuarioFuncaoId_Internalname ;
      private string sStyleString ;
      private string subGridlevel_usuario_Internalname ;
      private string AV21Pgmname ;
      private string Gxuitabspanel_tabs1_Objectcall ;
      private string Gxuitabspanel_tabs1_Activepagecontrolname ;
      private string Combo_usuarioid_Objectcall ;
      private string Combo_usuarioid_Class ;
      private string Combo_usuarioid_Icontype ;
      private string Combo_usuarioid_Icon ;
      private string Combo_usuarioid_Tooltip ;
      private string Combo_usuarioid_Selectedvalue_set ;
      private string Combo_usuarioid_Selectedvalue_get ;
      private string Combo_usuarioid_Selectedtext_set ;
      private string Combo_usuarioid_Selectedtext_get ;
      private string Combo_usuarioid_Gamoauthtoken ;
      private string Combo_usuarioid_Ddointernalname ;
      private string Combo_usuarioid_Titlecontrolalign ;
      private string Combo_usuarioid_Dropdownoptionstype ;
      private string Combo_usuarioid_Titlecontrolidtoreplace ;
      private string Combo_usuarioid_Datalisttype ;
      private string Combo_usuarioid_Datalistfixedvalues ;
      private string Combo_usuarioid_Datalistproc ;
      private string Combo_usuarioid_Datalistprocparametersprefix ;
      private string Combo_usuarioid_Remoteservicesparameters ;
      private string Combo_usuarioid_Htmltemplate ;
      private string Combo_usuarioid_Multiplevaluestype ;
      private string Combo_usuarioid_Loadingdata ;
      private string Combo_usuarioid_Noresultsfound ;
      private string Combo_usuarioid_Onlyselectedvalues ;
      private string Combo_usuarioid_Selectalltext ;
      private string Combo_usuarioid_Multiplevaluesseparator ;
      private string Combo_usuarioid_Addnewoptiontext ;
      private string hsh ;
      private string sMode101 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string A10UsuarioNome ;
      private string A174UsuarioFuncaoNome ;
      private string Z2EmpresaNome ;
      private string Z10UsuarioNome ;
      private string Z174UsuarioFuncaoNome ;
      private string GXCCtl ;
      private string sGXsfl_43_fel_idx="0001" ;
      private string subGridlevel_usuario_Class ;
      private string subGridlevel_usuario_Linesclass ;
      private string ROClassString ;
      private string edtAreaUsuarioId_Jsonclick ;
      private string edtUsuarioId_Jsonclick ;
      private string edtUsuarioNome_Jsonclick ;
      private string cmbUsuarioPerfil_Jsonclick ;
      private string edtUsuarioFuncaoNome_Jsonclick ;
      private string edtUsuarioFuncaoId_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlevel_usuario_Header ;
      private bool Z691AreaAtivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n173UsuarioFuncaoId ;
      private bool wbErr ;
      private bool bGXsfl_43_Refreshing=false ;
      private bool A691AreaAtivo ;
      private bool Gxuitabspanel_tabs1_Historymanagement ;
      private bool Combo_usuarioid_Isgriditem ;
      private bool A14UsuarioAtivo ;
      private bool Gxuitabspanel_tabs1_Enabled ;
      private bool Gxuitabspanel_tabs1_Visible ;
      private bool Combo_usuarioid_Enabled ;
      private bool Combo_usuarioid_Visible ;
      private bool Combo_usuarioid_Allowmultipleselection ;
      private bool Combo_usuarioid_Hasdescription ;
      private bool Combo_usuarioid_Includeonlyselectedoption ;
      private bool Combo_usuarioid_Includeselectalloption ;
      private bool Combo_usuarioid_Emptyitem ;
      private bool Combo_usuarioid_Includeaddnewoption ;
      private bool returnInSub ;
      private bool Z14UsuarioAtivo ;
      private bool i691AreaAtivo ;
      private string Z746AreaEmail ;
      private string A746AreaEmail ;
      private string A16UsuarioEmail ;
      private string AV18ComboSelectedValue ;
      private string Z16UsuarioEmail ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_usuarioContainer ;
      private GXWebRow Gridlevel_usuarioRow ;
      private GXWebColumn Gridlevel_usuarioColumn ;
      private GXUserControl ucGxuitabspanel_tabs1 ;
      private GXUserControl ucCombo_usuarioid ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkAreaAtivo ;
      private GXCombobox cmbUsuarioPerfil ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV17UsuarioId_Data ;
      private SdtSDTContexto AV16SDTContexto ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item1 ;
      private IDataStoreProvider pr_default ;
      private string[] T002K8_A2EmpresaNome ;
      private long[] T002K9_A689AreaId ;
      private string[] T002K9_A690AreaNome ;
      private bool[] T002K9_A691AreaAtivo ;
      private short[] T002K9_A692AreaLine ;
      private string[] T002K9_A746AreaEmail ;
      private string[] T002K9_A2EmpresaNome ;
      private long[] T002K9_A1EmpresaId ;
      private string[] T002K10_A2EmpresaNome ;
      private long[] T002K11_A689AreaId ;
      private long[] T002K7_A689AreaId ;
      private string[] T002K7_A690AreaNome ;
      private bool[] T002K7_A691AreaAtivo ;
      private short[] T002K7_A692AreaLine ;
      private string[] T002K7_A746AreaEmail ;
      private long[] T002K7_A1EmpresaId ;
      private long[] T002K12_A689AreaId ;
      private long[] T002K13_A689AreaId ;
      private long[] T002K6_A689AreaId ;
      private string[] T002K6_A690AreaNome ;
      private bool[] T002K6_A691AreaAtivo ;
      private short[] T002K6_A692AreaLine ;
      private string[] T002K6_A746AreaEmail ;
      private long[] T002K6_A1EmpresaId ;
      private long[] T002K14_A689AreaId ;
      private string[] T002K17_A2EmpresaNome ;
      private long[] T002K18_A702DocumentoId ;
      private long[] T002K20_A689AreaId ;
      private long[] T002K21_A689AreaId ;
      private long[] T002K21_A693AreaUsuarioId ;
      private string[] T002K21_A10UsuarioNome ;
      private string[] T002K21_A174UsuarioFuncaoNome ;
      private short[] T002K21_A11UsuarioPerfil ;
      private string[] T002K21_A16UsuarioEmail ;
      private bool[] T002K21_A14UsuarioAtivo ;
      private long[] T002K21_A9UsuarioId ;
      private long[] T002K21_A173UsuarioFuncaoId ;
      private bool[] T002K21_n173UsuarioFuncaoId ;
      private string[] T002K4_A10UsuarioNome ;
      private short[] T002K4_A11UsuarioPerfil ;
      private string[] T002K4_A16UsuarioEmail ;
      private bool[] T002K4_A14UsuarioAtivo ;
      private long[] T002K4_A173UsuarioFuncaoId ;
      private bool[] T002K4_n173UsuarioFuncaoId ;
      private string[] T002K5_A174UsuarioFuncaoNome ;
      private string[] T002K22_A10UsuarioNome ;
      private short[] T002K22_A11UsuarioPerfil ;
      private string[] T002K22_A16UsuarioEmail ;
      private bool[] T002K22_A14UsuarioAtivo ;
      private long[] T002K22_A173UsuarioFuncaoId ;
      private bool[] T002K22_n173UsuarioFuncaoId ;
      private string[] T002K23_A174UsuarioFuncaoNome ;
      private long[] T002K24_A689AreaId ;
      private long[] T002K24_A693AreaUsuarioId ;
      private long[] T002K3_A689AreaId ;
      private long[] T002K3_A693AreaUsuarioId ;
      private long[] T002K3_A9UsuarioId ;
      private long[] T002K2_A689AreaId ;
      private long[] T002K2_A693AreaUsuarioId ;
      private long[] T002K2_A9UsuarioId ;
      private string[] T002K28_A10UsuarioNome ;
      private short[] T002K28_A11UsuarioPerfil ;
      private string[] T002K28_A16UsuarioEmail ;
      private bool[] T002K28_A14UsuarioAtivo ;
      private long[] T002K28_A173UsuarioFuncaoId ;
      private bool[] T002K28_n173UsuarioFuncaoId ;
      private string[] T002K29_A174UsuarioFuncaoNome ;
      private long[] T002K30_A689AreaId ;
      private long[] T002K30_A693AreaUsuarioId ;
      private IDataStoreProvider pr_gam ;
   }

   public class area__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class area__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new UpdateCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002K2;
        prmT002K2 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0) ,
        new ParDef("@AreaUsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002K3;
        prmT002K3 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0) ,
        new ParDef("@AreaUsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002K4;
        prmT002K4 = new Object[] {
        new ParDef("@UsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002K5;
        prmT002K5 = new Object[] {
        new ParDef("@UsuarioFuncaoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002K6;
        prmT002K6 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0)
        };
        Object[] prmT002K7;
        prmT002K7 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0)
        };
        Object[] prmT002K8;
        prmT002K8 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,18,0)
        };
        Object[] prmT002K9;
        prmT002K9 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0)
        };
        Object[] prmT002K10;
        prmT002K10 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,18,0)
        };
        Object[] prmT002K11;
        prmT002K11 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0)
        };
        Object[] prmT002K12;
        prmT002K12 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0)
        };
        Object[] prmT002K13;
        prmT002K13 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0)
        };
        Object[] prmT002K14;
        prmT002K14 = new Object[] {
        new ParDef("@AreaNome",GXType.NChar,60,0) ,
        new ParDef("@AreaAtivo",GXType.Boolean,4,0) ,
        new ParDef("@AreaLine",GXType.Int16,4,0) ,
        new ParDef("@AreaEmail",GXType.NVarChar,100,0) ,
        new ParDef("@EmpresaId",GXType.Decimal,18,0)
        };
        Object[] prmT002K15;
        prmT002K15 = new Object[] {
        new ParDef("@AreaNome",GXType.NChar,60,0) ,
        new ParDef("@AreaAtivo",GXType.Boolean,4,0) ,
        new ParDef("@AreaLine",GXType.Int16,4,0) ,
        new ParDef("@AreaEmail",GXType.NVarChar,100,0) ,
        new ParDef("@EmpresaId",GXType.Decimal,18,0) ,
        new ParDef("@AreaId",GXType.Decimal,18,0)
        };
        Object[] prmT002K16;
        prmT002K16 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0)
        };
        Object[] prmT002K17;
        prmT002K17 = new Object[] {
        new ParDef("@EmpresaId",GXType.Decimal,18,0)
        };
        Object[] prmT002K18;
        prmT002K18 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0)
        };
        Object[] prmT002K19;
        prmT002K19 = new Object[] {
        new ParDef("@AreaLine",GXType.Int16,4,0) ,
        new ParDef("@AreaId",GXType.Decimal,18,0)
        };
        Object[] prmT002K20;
        prmT002K20 = new Object[] {
        };
        Object[] prmT002K21;
        prmT002K21 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0) ,
        new ParDef("@AreaUsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002K22;
        prmT002K22 = new Object[] {
        new ParDef("@UsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002K23;
        prmT002K23 = new Object[] {
        new ParDef("@UsuarioFuncaoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002K24;
        prmT002K24 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0) ,
        new ParDef("@AreaUsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002K25;
        prmT002K25 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0) ,
        new ParDef("@AreaUsuarioId",GXType.Decimal,18,0) ,
        new ParDef("@UsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002K26;
        prmT002K26 = new Object[] {
        new ParDef("@UsuarioId",GXType.Decimal,18,0) ,
        new ParDef("@AreaId",GXType.Decimal,18,0) ,
        new ParDef("@AreaUsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002K27;
        prmT002K27 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0) ,
        new ParDef("@AreaUsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002K28;
        prmT002K28 = new Object[] {
        new ParDef("@UsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002K29;
        prmT002K29 = new Object[] {
        new ParDef("@UsuarioFuncaoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002K30;
        prmT002K30 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002K2", "SELECT [AreaId], [AreaUsuarioId], [UsuarioId] FROM [AreaUsuario] WITH (UPDLOCK) WHERE [AreaId] = @AreaId AND [AreaUsuarioId] = @AreaUsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K3", "SELECT [AreaId], [AreaUsuarioId], [UsuarioId] FROM [AreaUsuario] WHERE [AreaId] = @AreaId AND [AreaUsuarioId] = @AreaUsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K4", "SELECT [UsuarioNome], [UsuarioPerfil], [UsuarioEmail], [UsuarioAtivo], [UsuarioFuncaoId] AS UsuarioFuncaoId FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K5", "SELECT [FuncaoNome] AS UsuarioFuncaoNome FROM [Funcao] WHERE [FuncaoId] = @UsuarioFuncaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K6", "SELECT [AreaId], [AreaNome], [AreaAtivo], [AreaLine], [AreaEmail], [EmpresaId] FROM [Area] WITH (UPDLOCK) WHERE [AreaId] = @AreaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K7", "SELECT [AreaId], [AreaNome], [AreaAtivo], [AreaLine], [AreaEmail], [EmpresaId] FROM [Area] WHERE [AreaId] = @AreaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K8", "SELECT [EmpresaNome] FROM [Empresa] WHERE [EmpresaId] = @EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K9", "SELECT TM1.[AreaId], TM1.[AreaNome], TM1.[AreaAtivo], TM1.[AreaLine], TM1.[AreaEmail], T2.[EmpresaNome], TM1.[EmpresaId] FROM ([Area] TM1 INNER JOIN [Empresa] T2 ON T2.[EmpresaId] = TM1.[EmpresaId]) WHERE TM1.[AreaId] = @AreaId ORDER BY TM1.[AreaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002K9,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K10", "SELECT [EmpresaNome] FROM [Empresa] WHERE [EmpresaId] = @EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K11", "SELECT [AreaId] FROM [Area] WHERE [AreaId] = @AreaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002K11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K12", "SELECT TOP 1 [AreaId] FROM [Area] WHERE ( [AreaId] > @AreaId) ORDER BY [AreaId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002K12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002K13", "SELECT TOP 1 [AreaId] FROM [Area] WHERE ( [AreaId] < @AreaId) ORDER BY [AreaId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002K13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002K14", "INSERT INTO [Area]([AreaNome], [AreaAtivo], [AreaLine], [AreaEmail], [EmpresaId]) VALUES(@AreaNome, @AreaAtivo, @AreaLine, @AreaEmail, @EmpresaId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT002K14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002K15", "UPDATE [Area] SET [AreaNome]=@AreaNome, [AreaAtivo]=@AreaAtivo, [AreaLine]=@AreaLine, [AreaEmail]=@AreaEmail, [EmpresaId]=@EmpresaId  WHERE [AreaId] = @AreaId", GxErrorMask.GX_NOMASK,prmT002K15)
           ,new CursorDef("T002K16", "DELETE FROM [Area]  WHERE [AreaId] = @AreaId", GxErrorMask.GX_NOMASK,prmT002K16)
           ,new CursorDef("T002K17", "SELECT [EmpresaNome] FROM [Empresa] WHERE [EmpresaId] = @EmpresaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K18", "SELECT TOP 1 [DocumentoId] FROM [Documento] WHERE [DocumentoAreaId] = @AreaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002K19", "UPDATE [Area] SET [AreaLine]=@AreaLine  WHERE [AreaId] = @AreaId", GxErrorMask.GX_NOMASK,prmT002K19)
           ,new CursorDef("T002K20", "SELECT [AreaId] FROM [Area] ORDER BY [AreaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002K20,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K21", "SELECT T1.[AreaId], T1.[AreaUsuarioId], T2.[UsuarioNome], T3.[FuncaoNome] AS UsuarioFuncaoNome, T2.[UsuarioPerfil], T2.[UsuarioEmail], T2.[UsuarioAtivo], T1.[UsuarioId], T2.[UsuarioFuncaoId] AS UsuarioFuncaoId FROM (([AreaUsuario] T1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = T1.[UsuarioId]) LEFT JOIN [Funcao] T3 ON T3.[FuncaoId] = T2.[UsuarioFuncaoId]) WHERE T1.[AreaId] = @AreaId and T1.[AreaUsuarioId] = @AreaUsuarioId ORDER BY T1.[AreaId], T1.[AreaUsuarioId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K21,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K22", "SELECT [UsuarioNome], [UsuarioPerfil], [UsuarioEmail], [UsuarioAtivo], [UsuarioFuncaoId] AS UsuarioFuncaoId FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K23", "SELECT [FuncaoNome] AS UsuarioFuncaoNome FROM [Funcao] WHERE [FuncaoId] = @UsuarioFuncaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K24", "SELECT [AreaId], [AreaUsuarioId] FROM [AreaUsuario] WHERE [AreaId] = @AreaId AND [AreaUsuarioId] = @AreaUsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K25", "INSERT INTO [AreaUsuario]([AreaId], [AreaUsuarioId], [UsuarioId]) VALUES(@AreaId, @AreaUsuarioId, @UsuarioId)", GxErrorMask.GX_NOMASK,prmT002K25)
           ,new CursorDef("T002K26", "UPDATE [AreaUsuario] SET [UsuarioId]=@UsuarioId  WHERE [AreaId] = @AreaId AND [AreaUsuarioId] = @AreaUsuarioId", GxErrorMask.GX_NOMASK,prmT002K26)
           ,new CursorDef("T002K27", "DELETE FROM [AreaUsuario]  WHERE [AreaId] = @AreaId AND [AreaUsuarioId] = @AreaUsuarioId", GxErrorMask.GX_NOMASK,prmT002K27)
           ,new CursorDef("T002K28", "SELECT [UsuarioNome], [UsuarioPerfil], [UsuarioEmail], [UsuarioAtivo], [UsuarioFuncaoId] AS UsuarioFuncaoId FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K29", "SELECT [FuncaoNome] AS UsuarioFuncaoNome FROM [Funcao] WHERE [FuncaoId] = @UsuarioFuncaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002K30", "SELECT [AreaId], [AreaUsuarioId] FROM [AreaUsuario] WHERE [AreaId] = @AreaId ORDER BY [AreaId], [AreaUsuarioId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002K30,11, GxCacheFrequency.OFF ,true,false )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 0 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 60);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 60);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 60);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 60);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 60);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 60);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 60);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 60);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 60);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 60);
              ((string[]) buf[3])[0] = rslt.getString(4, 60);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 60);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 60);
              return;
           case 22 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 60);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getString(1, 60);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
  }

}

}

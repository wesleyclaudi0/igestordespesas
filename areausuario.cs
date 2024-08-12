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
   public class areausuario : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         gxfirstwebparm = GetNextPar( );
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A689AreaId = (long)(Math.Round(NumberUtil.Val( GetPar( "AreaId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A689AreaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A9UsuarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "UsuarioId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A9UsuarioId", StringUtil.LTrimStr( (decimal)(A9UsuarioId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A9UsuarioId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A173UsuarioFuncaoId = (long)(Math.Round(NumberUtil.Val( GetPar( "UsuarioFuncaoId"), "."), 18, MidpointRounding.ToEven));
            n173UsuarioFuncaoId = false;
            AssignAttri("", false, "A173UsuarioFuncaoId", StringUtil.LTrimStr( (decimal)(A173UsuarioFuncaoId), 18, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A173UsuarioFuncaoId) ;
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
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
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
         Form.Meta.addItem("description", context.GetMessage( "Area Usuario", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAreaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public areausuario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public areausuario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbUsuarioPerfil = new GXCombobox();
         chkUsuarioAtivo = new GXCheckbox();
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
         if ( cmbUsuarioPerfil.ItemCount > 0 )
         {
            A11UsuarioPerfil = (short)(Math.Round(NumberUtil.Val( cmbUsuarioPerfil.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A11UsuarioPerfil), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A11UsuarioPerfil", StringUtil.LTrimStr( (decimal)(A11UsuarioPerfil), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUsuarioPerfil.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A11UsuarioPerfil), 4, 0));
            AssignProp("", false, cmbUsuarioPerfil_Internalname, "Values", cmbUsuarioPerfil.ToJavascriptSource(), true);
         }
         A14UsuarioAtivo = StringUtil.StrToBool( StringUtil.BoolToStr( A14UsuarioAtivo));
         AssignAttri("", false, "A14UsuarioAtivo", A14UsuarioAtivo);
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
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Area Usuario", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_AreaUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AreaUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_AreaUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_AreaUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AreaUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_AreaUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAreaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAreaId_Internalname, context.GetMessage( "Area Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAreaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A689AreaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtAreaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A689AreaId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A689AreaId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAreaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAreaId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, 0, true, "Id", "end", false, "", "HLP_AreaUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAreaUsuarioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAreaUsuarioId_Internalname, context.GetMessage( "Usuario Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAreaUsuarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A693AreaUsuarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtAreaUsuarioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A693AreaUsuarioId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A693AreaUsuarioId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAreaUsuarioId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAreaUsuarioId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, 0, true, "Id", "end", false, "", "HLP_AreaUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioId_Internalname, context.GetMessage( "Id", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9UsuarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A9UsuarioId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A9UsuarioId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, 0, true, "Id", "end", false, "", "HLP_AreaUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioNome_Internalname, context.GetMessage( "Nome", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUsuarioNome_Internalname, StringUtil.RTrim( A10UsuarioNome), StringUtil.RTrim( context.localUtil.Format( A10UsuarioNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioNome_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nome", "start", true, "", "HLP_AreaUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioFuncaoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioFuncaoId_Internalname, context.GetMessage( "Função", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUsuarioFuncaoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A173UsuarioFuncaoId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtUsuarioFuncaoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A173UsuarioFuncaoId), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A173UsuarioFuncaoId), "ZZZZZZZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioFuncaoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioFuncaoId_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, 0, true, "Id", "end", false, "", "HLP_AreaUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioFuncaoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioFuncaoNome_Internalname, context.GetMessage( "Função", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUsuarioFuncaoNome_Internalname, StringUtil.RTrim( A174UsuarioFuncaoNome), StringUtil.RTrim( context.localUtil.Format( A174UsuarioFuncaoNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioFuncaoNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioFuncaoNome_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nome", "start", true, "", "HLP_AreaUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbUsuarioPerfil_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbUsuarioPerfil_Internalname, context.GetMessage( "Perfil", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUsuarioPerfil, cmbUsuarioPerfil_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A11UsuarioPerfil), 4, 0)), 1, cmbUsuarioPerfil_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbUsuarioPerfil.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 1, "HLP_AreaUsuario.htm");
         cmbUsuarioPerfil.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A11UsuarioPerfil), 4, 0));
         AssignProp("", false, cmbUsuarioPerfil_Internalname, "Values", (string)(cmbUsuarioPerfil.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtUsuarioEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioEmail_Internalname, context.GetMessage( "Email", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUsuarioEmail_Internalname, A16UsuarioEmail, StringUtil.RTrim( context.localUtil.Format( A16UsuarioEmail, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A16UsuarioEmail, "", "", "", edtUsuarioEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_AreaUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkUsuarioAtivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuarioAtivo_Internalname, context.GetMessage( "Ativo", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuarioAtivo_Internalname, StringUtil.BoolToStr( A14UsuarioAtivo), "", context.GetMessage( "Ativo", ""), 1, chkUsuarioAtivo.Enabled, "true", "", StyleString, ClassString, "", "", "");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AreaUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AreaUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_AreaUsuario.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z689AreaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z689AreaId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z693AreaUsuarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z693AreaUsuarioId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z9UsuarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z9UsuarioId"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtAreaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAreaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AREAID");
               AnyError = 1;
               GX_FocusControl = edtAreaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A689AreaId = 0;
               AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
            }
            else
            {
               A689AreaId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAreaId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtAreaUsuarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAreaUsuarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AREAUSUARIOID");
               AnyError = 1;
               GX_FocusControl = edtAreaUsuarioId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A693AreaUsuarioId = 0;
               AssignAttri("", false, "A693AreaUsuarioId", StringUtil.LTrimStr( (decimal)(A693AreaUsuarioId), 18, 0));
            }
            else
            {
               A693AreaUsuarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtAreaUsuarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A693AreaUsuarioId", StringUtil.LTrimStr( (decimal)(A693AreaUsuarioId), 18, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 999999999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIOID");
               AnyError = 1;
               GX_FocusControl = edtUsuarioId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A9UsuarioId = 0;
               AssignAttri("", false, "A9UsuarioId", StringUtil.LTrimStr( (decimal)(A9UsuarioId), 18, 0));
            }
            else
            {
               A9UsuarioId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A9UsuarioId", StringUtil.LTrimStr( (decimal)(A9UsuarioId), 18, 0));
            }
            A10UsuarioNome = cgiGet( edtUsuarioNome_Internalname);
            AssignAttri("", false, "A10UsuarioNome", A10UsuarioNome);
            A173UsuarioFuncaoId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtUsuarioFuncaoId_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            n173UsuarioFuncaoId = false;
            AssignAttri("", false, "A173UsuarioFuncaoId", StringUtil.LTrimStr( (decimal)(A173UsuarioFuncaoId), 18, 0));
            A174UsuarioFuncaoNome = cgiGet( edtUsuarioFuncaoNome_Internalname);
            AssignAttri("", false, "A174UsuarioFuncaoNome", A174UsuarioFuncaoNome);
            cmbUsuarioPerfil.CurrentValue = cgiGet( cmbUsuarioPerfil_Internalname);
            A11UsuarioPerfil = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbUsuarioPerfil_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A11UsuarioPerfil", StringUtil.LTrimStr( (decimal)(A11UsuarioPerfil), 4, 0));
            A16UsuarioEmail = cgiGet( edtUsuarioEmail_Internalname);
            AssignAttri("", false, "A16UsuarioEmail", A16UsuarioEmail);
            A14UsuarioAtivo = StringUtil.StrToBool( cgiGet( chkUsuarioAtivo_Internalname));
            AssignAttri("", false, "A14UsuarioAtivo", A14UsuarioAtivo);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
               A693AreaUsuarioId = (long)(Math.Round(NumberUtil.Val( GetPar( "AreaUsuarioId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A693AreaUsuarioId", StringUtil.LTrimStr( (decimal)(A693AreaUsuarioId), 18, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2L102( ) ;
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
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes2L102( ) ;
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

      protected void ResetCaption2L0( )
      {
      }

      protected void ZM2L102( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z9UsuarioId = T002L3_A9UsuarioId[0];
            }
            else
            {
               Z9UsuarioId = A9UsuarioId;
            }
         }
         if ( GX_JID == -1 )
         {
            Z693AreaUsuarioId = A693AreaUsuarioId;
            Z689AreaId = A689AreaId;
            Z9UsuarioId = A9UsuarioId;
            Z10UsuarioNome = A10UsuarioNome;
            Z11UsuarioPerfil = A11UsuarioPerfil;
            Z16UsuarioEmail = A16UsuarioEmail;
            Z14UsuarioAtivo = A14UsuarioAtivo;
            Z173UsuarioFuncaoId = A173UsuarioFuncaoId;
            Z174UsuarioFuncaoNome = A174UsuarioFuncaoNome;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load2L102( )
      {
         /* Using cursor T002L7 */
         pr_default.execute(5, new Object[] {A689AreaId, A693AreaUsuarioId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound102 = 1;
            A10UsuarioNome = T002L7_A10UsuarioNome[0];
            AssignAttri("", false, "A10UsuarioNome", A10UsuarioNome);
            A174UsuarioFuncaoNome = T002L7_A174UsuarioFuncaoNome[0];
            AssignAttri("", false, "A174UsuarioFuncaoNome", A174UsuarioFuncaoNome);
            A11UsuarioPerfil = T002L7_A11UsuarioPerfil[0];
            AssignAttri("", false, "A11UsuarioPerfil", StringUtil.LTrimStr( (decimal)(A11UsuarioPerfil), 4, 0));
            A16UsuarioEmail = T002L7_A16UsuarioEmail[0];
            AssignAttri("", false, "A16UsuarioEmail", A16UsuarioEmail);
            A14UsuarioAtivo = T002L7_A14UsuarioAtivo[0];
            AssignAttri("", false, "A14UsuarioAtivo", A14UsuarioAtivo);
            A9UsuarioId = T002L7_A9UsuarioId[0];
            AssignAttri("", false, "A9UsuarioId", StringUtil.LTrimStr( (decimal)(A9UsuarioId), 18, 0));
            A173UsuarioFuncaoId = T002L7_A173UsuarioFuncaoId[0];
            n173UsuarioFuncaoId = T002L7_n173UsuarioFuncaoId[0];
            AssignAttri("", false, "A173UsuarioFuncaoId", StringUtil.LTrimStr( (decimal)(A173UsuarioFuncaoId), 18, 0));
            ZM2L102( -1) ;
         }
         pr_default.close(5);
         OnLoadActions2L102( ) ;
      }

      protected void OnLoadActions2L102( )
      {
      }

      protected void CheckExtendedTable2L102( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002L4 */
         pr_default.execute(2, new Object[] {A689AreaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Área", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AREAID");
            AnyError = 1;
            GX_FocusControl = edtAreaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T002L5 */
         pr_default.execute(3, new Object[] {A9UsuarioId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10UsuarioNome = T002L5_A10UsuarioNome[0];
         AssignAttri("", false, "A10UsuarioNome", A10UsuarioNome);
         A11UsuarioPerfil = T002L5_A11UsuarioPerfil[0];
         AssignAttri("", false, "A11UsuarioPerfil", StringUtil.LTrimStr( (decimal)(A11UsuarioPerfil), 4, 0));
         A16UsuarioEmail = T002L5_A16UsuarioEmail[0];
         AssignAttri("", false, "A16UsuarioEmail", A16UsuarioEmail);
         A14UsuarioAtivo = T002L5_A14UsuarioAtivo[0];
         AssignAttri("", false, "A14UsuarioAtivo", A14UsuarioAtivo);
         A173UsuarioFuncaoId = T002L5_A173UsuarioFuncaoId[0];
         n173UsuarioFuncaoId = T002L5_n173UsuarioFuncaoId[0];
         AssignAttri("", false, "A173UsuarioFuncaoId", StringUtil.LTrimStr( (decimal)(A173UsuarioFuncaoId), 18, 0));
         pr_default.close(3);
         /* Using cursor T002L6 */
         pr_default.execute(4, new Object[] {n173UsuarioFuncaoId, A173UsuarioFuncaoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A173UsuarioFuncaoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SGUsuario Funcao", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOFUNCAOID");
               AnyError = 1;
            }
         }
         A174UsuarioFuncaoNome = T002L6_A174UsuarioFuncaoNome[0];
         AssignAttri("", false, "A174UsuarioFuncaoNome", A174UsuarioFuncaoNome);
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors2L102( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( long A689AreaId )
      {
         /* Using cursor T002L8 */
         pr_default.execute(6, new Object[] {A689AreaId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Área", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AREAID");
            AnyError = 1;
            GX_FocusControl = edtAreaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_3( long A9UsuarioId )
      {
         /* Using cursor T002L9 */
         pr_default.execute(7, new Object[] {A9UsuarioId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10UsuarioNome = T002L9_A10UsuarioNome[0];
         AssignAttri("", false, "A10UsuarioNome", A10UsuarioNome);
         A11UsuarioPerfil = T002L9_A11UsuarioPerfil[0];
         AssignAttri("", false, "A11UsuarioPerfil", StringUtil.LTrimStr( (decimal)(A11UsuarioPerfil), 4, 0));
         A16UsuarioEmail = T002L9_A16UsuarioEmail[0];
         AssignAttri("", false, "A16UsuarioEmail", A16UsuarioEmail);
         A14UsuarioAtivo = T002L9_A14UsuarioAtivo[0];
         AssignAttri("", false, "A14UsuarioAtivo", A14UsuarioAtivo);
         A173UsuarioFuncaoId = T002L9_A173UsuarioFuncaoId[0];
         n173UsuarioFuncaoId = T002L9_n173UsuarioFuncaoId[0];
         AssignAttri("", false, "A173UsuarioFuncaoId", StringUtil.LTrimStr( (decimal)(A173UsuarioFuncaoId), 18, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A10UsuarioNome))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuarioPerfil), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A16UsuarioEmail)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A14UsuarioAtivo))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A173UsuarioFuncaoId), 18, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_4( long A173UsuarioFuncaoId )
      {
         /* Using cursor T002L10 */
         pr_default.execute(8, new Object[] {n173UsuarioFuncaoId, A173UsuarioFuncaoId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A173UsuarioFuncaoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SGUsuario Funcao", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOFUNCAOID");
               AnyError = 1;
            }
         }
         A174UsuarioFuncaoNome = T002L10_A174UsuarioFuncaoNome[0];
         AssignAttri("", false, "A174UsuarioFuncaoNome", A174UsuarioFuncaoNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A174UsuarioFuncaoNome))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey2L102( )
      {
         /* Using cursor T002L11 */
         pr_default.execute(9, new Object[] {A689AreaId, A693AreaUsuarioId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound102 = 1;
         }
         else
         {
            RcdFound102 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002L3 */
         pr_default.execute(1, new Object[] {A689AreaId, A693AreaUsuarioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2L102( 1) ;
            RcdFound102 = 1;
            A693AreaUsuarioId = T002L3_A693AreaUsuarioId[0];
            AssignAttri("", false, "A693AreaUsuarioId", StringUtil.LTrimStr( (decimal)(A693AreaUsuarioId), 18, 0));
            A689AreaId = T002L3_A689AreaId[0];
            AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
            A9UsuarioId = T002L3_A9UsuarioId[0];
            AssignAttri("", false, "A9UsuarioId", StringUtil.LTrimStr( (decimal)(A9UsuarioId), 18, 0));
            Z689AreaId = A689AreaId;
            Z693AreaUsuarioId = A693AreaUsuarioId;
            sMode102 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2L102( ) ;
            if ( AnyError == 1 )
            {
               RcdFound102 = 0;
               InitializeNonKey2L102( ) ;
            }
            Gx_mode = sMode102;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound102 = 0;
            InitializeNonKey2L102( ) ;
            sMode102 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode102;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2L102( ) ;
         if ( RcdFound102 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound102 = 0;
         /* Using cursor T002L12 */
         pr_default.execute(10, new Object[] {A689AreaId, A693AreaUsuarioId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T002L12_A689AreaId[0] < A689AreaId ) || ( T002L12_A689AreaId[0] == A689AreaId ) && ( T002L12_A693AreaUsuarioId[0] < A693AreaUsuarioId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T002L12_A689AreaId[0] > A689AreaId ) || ( T002L12_A689AreaId[0] == A689AreaId ) && ( T002L12_A693AreaUsuarioId[0] > A693AreaUsuarioId ) ) )
            {
               A689AreaId = T002L12_A689AreaId[0];
               AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
               A693AreaUsuarioId = T002L12_A693AreaUsuarioId[0];
               AssignAttri("", false, "A693AreaUsuarioId", StringUtil.LTrimStr( (decimal)(A693AreaUsuarioId), 18, 0));
               RcdFound102 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound102 = 0;
         /* Using cursor T002L13 */
         pr_default.execute(11, new Object[] {A689AreaId, A693AreaUsuarioId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T002L13_A689AreaId[0] > A689AreaId ) || ( T002L13_A689AreaId[0] == A689AreaId ) && ( T002L13_A693AreaUsuarioId[0] > A693AreaUsuarioId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T002L13_A689AreaId[0] < A689AreaId ) || ( T002L13_A689AreaId[0] == A689AreaId ) && ( T002L13_A693AreaUsuarioId[0] < A693AreaUsuarioId ) ) )
            {
               A689AreaId = T002L13_A689AreaId[0];
               AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
               A693AreaUsuarioId = T002L13_A693AreaUsuarioId[0];
               AssignAttri("", false, "A693AreaUsuarioId", StringUtil.LTrimStr( (decimal)(A693AreaUsuarioId), 18, 0));
               RcdFound102 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2L102( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAreaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2L102( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound102 == 1 )
            {
               if ( ( A689AreaId != Z689AreaId ) || ( A693AreaUsuarioId != Z693AreaUsuarioId ) )
               {
                  A689AreaId = Z689AreaId;
                  AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
                  A693AreaUsuarioId = Z693AreaUsuarioId;
                  AssignAttri("", false, "A693AreaUsuarioId", StringUtil.LTrimStr( (decimal)(A693AreaUsuarioId), 18, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AREAID");
                  AnyError = 1;
                  GX_FocusControl = edtAreaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAreaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2L102( ) ;
                  GX_FocusControl = edtAreaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A689AreaId != Z689AreaId ) || ( A693AreaUsuarioId != Z693AreaUsuarioId ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAreaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2L102( ) ;
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
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAreaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2L102( ) ;
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
      }

      protected void btn_delete( )
      {
         if ( ( A689AreaId != Z689AreaId ) || ( A693AreaUsuarioId != Z693AreaUsuarioId ) )
         {
            A689AreaId = Z689AreaId;
            AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
            A693AreaUsuarioId = Z693AreaUsuarioId;
            AssignAttri("", false, "A693AreaUsuarioId", StringUtil.LTrimStr( (decimal)(A693AreaUsuarioId), 18, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AREAID");
            AnyError = 1;
            GX_FocusControl = edtAreaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAreaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound102 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "AREAID");
            AnyError = 1;
            GX_FocusControl = edtAreaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtUsuarioId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2L102( ) ;
         if ( RcdFound102 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuarioId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2L102( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound102 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuarioId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound102 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuarioId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2L102( ) ;
         if ( RcdFound102 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound102 != 0 )
            {
               ScanNext2L102( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuarioId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2L102( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2L102( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002L2 */
            pr_default.execute(0, new Object[] {A689AreaId, A693AreaUsuarioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AreaUsuario"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z9UsuarioId != T002L2_A9UsuarioId[0] ) )
            {
               if ( Z9UsuarioId != T002L2_A9UsuarioId[0] )
               {
                  GXUtil.WriteLog("areausuario:[seudo value changed for attri]"+"UsuarioId");
                  GXUtil.WriteLogRaw("Old: ",Z9UsuarioId);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A9UsuarioId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AreaUsuario"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2L102( )
      {
         BeforeValidate2L102( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2L102( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2L102( 0) ;
            CheckOptimisticConcurrency2L102( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2L102( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2L102( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002L14 */
                     pr_default.execute(12, new Object[] {A693AreaUsuarioId, A689AreaId, A9UsuarioId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("AreaUsuario");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2L0( ) ;
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
               Load2L102( ) ;
            }
            EndLevel2L102( ) ;
         }
         CloseExtendedTableCursors2L102( ) ;
      }

      protected void Update2L102( )
      {
         BeforeValidate2L102( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2L102( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2L102( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2L102( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2L102( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002L15 */
                     pr_default.execute(13, new Object[] {A9UsuarioId, A689AreaId, A693AreaUsuarioId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("AreaUsuario");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AreaUsuario"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2L102( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2L0( ) ;
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
            EndLevel2L102( ) ;
         }
         CloseExtendedTableCursors2L102( ) ;
      }

      protected void DeferredUpdate2L102( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2L102( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2L102( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2L102( ) ;
            AfterConfirm2L102( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2L102( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002L16 */
                  pr_default.execute(14, new Object[] {A689AreaId, A693AreaUsuarioId});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("AreaUsuario");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound102 == 0 )
                        {
                           InitAll2L102( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption2L0( ) ;
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
         sMode102 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2L102( ) ;
         Gx_mode = sMode102;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2L102( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002L17 */
            pr_default.execute(15, new Object[] {A9UsuarioId});
            A10UsuarioNome = T002L17_A10UsuarioNome[0];
            AssignAttri("", false, "A10UsuarioNome", A10UsuarioNome);
            A11UsuarioPerfil = T002L17_A11UsuarioPerfil[0];
            AssignAttri("", false, "A11UsuarioPerfil", StringUtil.LTrimStr( (decimal)(A11UsuarioPerfil), 4, 0));
            A16UsuarioEmail = T002L17_A16UsuarioEmail[0];
            AssignAttri("", false, "A16UsuarioEmail", A16UsuarioEmail);
            A14UsuarioAtivo = T002L17_A14UsuarioAtivo[0];
            AssignAttri("", false, "A14UsuarioAtivo", A14UsuarioAtivo);
            A173UsuarioFuncaoId = T002L17_A173UsuarioFuncaoId[0];
            n173UsuarioFuncaoId = T002L17_n173UsuarioFuncaoId[0];
            AssignAttri("", false, "A173UsuarioFuncaoId", StringUtil.LTrimStr( (decimal)(A173UsuarioFuncaoId), 18, 0));
            pr_default.close(15);
            /* Using cursor T002L18 */
            pr_default.execute(16, new Object[] {n173UsuarioFuncaoId, A173UsuarioFuncaoId});
            A174UsuarioFuncaoNome = T002L18_A174UsuarioFuncaoNome[0];
            AssignAttri("", false, "A174UsuarioFuncaoNome", A174UsuarioFuncaoNome);
            pr_default.close(16);
         }
      }

      protected void EndLevel2L102( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2L102( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.CommitDataStores("areausuario",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.RollbackDataStores("areausuario",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2L102( )
      {
         /* Using cursor T002L19 */
         pr_default.execute(17);
         RcdFound102 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound102 = 1;
            A689AreaId = T002L19_A689AreaId[0];
            AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
            A693AreaUsuarioId = T002L19_A693AreaUsuarioId[0];
            AssignAttri("", false, "A693AreaUsuarioId", StringUtil.LTrimStr( (decimal)(A693AreaUsuarioId), 18, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2L102( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound102 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound102 = 1;
            A689AreaId = T002L19_A689AreaId[0];
            AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
            A693AreaUsuarioId = T002L19_A693AreaUsuarioId[0];
            AssignAttri("", false, "A693AreaUsuarioId", StringUtil.LTrimStr( (decimal)(A693AreaUsuarioId), 18, 0));
         }
      }

      protected void ScanEnd2L102( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm2L102( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2L102( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2L102( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2L102( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2L102( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2L102( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2L102( )
      {
         edtAreaId_Enabled = 0;
         AssignProp("", false, edtAreaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaId_Enabled), 5, 0), true);
         edtAreaUsuarioId_Enabled = 0;
         AssignProp("", false, edtAreaUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreaUsuarioId_Enabled), 5, 0), true);
         edtUsuarioId_Enabled = 0;
         AssignProp("", false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), true);
         edtUsuarioNome_Enabled = 0;
         AssignProp("", false, edtUsuarioNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNome_Enabled), 5, 0), true);
         edtUsuarioFuncaoId_Enabled = 0;
         AssignProp("", false, edtUsuarioFuncaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFuncaoId_Enabled), 5, 0), true);
         edtUsuarioFuncaoNome_Enabled = 0;
         AssignProp("", false, edtUsuarioFuncaoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFuncaoNome_Enabled), 5, 0), true);
         cmbUsuarioPerfil.Enabled = 0;
         AssignProp("", false, cmbUsuarioPerfil_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUsuarioPerfil.Enabled), 5, 0), true);
         edtUsuarioEmail_Enabled = 0;
         AssignProp("", false, edtUsuarioEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioEmail_Enabled), 5, 0), true);
         chkUsuarioAtivo.Enabled = 0;
         AssignProp("", false, chkUsuarioAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuarioAtivo.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2L102( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2L0( )
      {
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("areausuario.aspx") +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z689AreaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z689AreaId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z693AreaUsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z693AreaUsuarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z9UsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9UsuarioId), 18, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         return formatLink("areausuario.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AreaUsuario" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Area Usuario", "") ;
      }

      protected void InitializeNonKey2L102( )
      {
         A9UsuarioId = 0;
         AssignAttri("", false, "A9UsuarioId", StringUtil.LTrimStr( (decimal)(A9UsuarioId), 18, 0));
         A10UsuarioNome = "";
         AssignAttri("", false, "A10UsuarioNome", A10UsuarioNome);
         A173UsuarioFuncaoId = 0;
         n173UsuarioFuncaoId = false;
         AssignAttri("", false, "A173UsuarioFuncaoId", StringUtil.LTrimStr( (decimal)(A173UsuarioFuncaoId), 18, 0));
         A174UsuarioFuncaoNome = "";
         AssignAttri("", false, "A174UsuarioFuncaoNome", A174UsuarioFuncaoNome);
         A11UsuarioPerfil = 0;
         AssignAttri("", false, "A11UsuarioPerfil", StringUtil.LTrimStr( (decimal)(A11UsuarioPerfil), 4, 0));
         A16UsuarioEmail = "";
         AssignAttri("", false, "A16UsuarioEmail", A16UsuarioEmail);
         A14UsuarioAtivo = false;
         AssignAttri("", false, "A14UsuarioAtivo", A14UsuarioAtivo);
         Z9UsuarioId = 0;
      }

      protected void InitAll2L102( )
      {
         A689AreaId = 0;
         AssignAttri("", false, "A689AreaId", StringUtil.LTrimStr( (decimal)(A689AreaId), 18, 0));
         A693AreaUsuarioId = 0;
         AssignAttri("", false, "A693AreaUsuarioId", StringUtil.LTrimStr( (decimal)(A693AreaUsuarioId), 18, 0));
         InitializeNonKey2L102( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202461819381863", true, true);
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
         context.AddJavascriptSource("areausuario.js", "?202461819381863", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtAreaId_Internalname = "AREAID";
         edtAreaUsuarioId_Internalname = "AREAUSUARIOID";
         edtUsuarioId_Internalname = "USUARIOID";
         edtUsuarioNome_Internalname = "USUARIONOME";
         edtUsuarioFuncaoId_Internalname = "USUARIOFUNCAOID";
         edtUsuarioFuncaoNome_Internalname = "USUARIOFUNCAONOME";
         cmbUsuarioPerfil_Internalname = "USUARIOPERFIL";
         edtUsuarioEmail_Internalname = "USUARIOEMAIL";
         chkUsuarioAtivo_Internalname = "USUARIOATIVO";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme", false);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = context.GetMessage( "Area Usuario", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkUsuarioAtivo.Enabled = 0;
         edtUsuarioEmail_Jsonclick = "";
         edtUsuarioEmail_Enabled = 0;
         cmbUsuarioPerfil_Jsonclick = "";
         cmbUsuarioPerfil.Enabled = 0;
         edtUsuarioFuncaoNome_Jsonclick = "";
         edtUsuarioFuncaoNome_Enabled = 0;
         edtUsuarioFuncaoId_Jsonclick = "";
         edtUsuarioFuncaoId_Enabled = 0;
         edtUsuarioNome_Jsonclick = "";
         edtUsuarioNome_Enabled = 0;
         edtUsuarioId_Jsonclick = "";
         edtUsuarioId_Enabled = 1;
         edtAreaUsuarioId_Jsonclick = "";
         edtAreaUsuarioId_Enabled = 1;
         edtAreaId_Jsonclick = "";
         edtAreaId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
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

      protected void init_web_controls( )
      {
         cmbUsuarioPerfil.Name = "USUARIOPERFIL";
         cmbUsuarioPerfil.WebTags = "";
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
            AssignAttri("", false, "A11UsuarioPerfil", StringUtil.LTrimStr( (decimal)(A11UsuarioPerfil), 4, 0));
         }
         chkUsuarioAtivo.Name = "USUARIOATIVO";
         chkUsuarioAtivo.WebTags = "";
         chkUsuarioAtivo.Caption = context.GetMessage( "Ativo", "");
         AssignProp("", false, chkUsuarioAtivo_Internalname, "TitleCaption", chkUsuarioAtivo.Caption, true);
         chkUsuarioAtivo.CheckedValue = "false";
         A14UsuarioAtivo = StringUtil.StrToBool( StringUtil.BoolToStr( A14UsuarioAtivo));
         AssignAttri("", false, "A14UsuarioAtivo", A14UsuarioAtivo);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T002L20 */
         pr_default.execute(18, new Object[] {A689AreaId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Área", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AREAID");
            AnyError = 1;
            GX_FocusControl = edtAreaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(18);
         GX_FocusControl = edtUsuarioId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Areaid( )
      {
         /* Using cursor T002L20 */
         pr_default.execute(18, new Object[] {A689AreaId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Área", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "AREAID");
            AnyError = 1;
            GX_FocusControl = edtAreaId_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Areausuarioid( )
      {
         A11UsuarioPerfil = (short)(Math.Round(NumberUtil.Val( cmbUsuarioPerfil.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbUsuarioPerfil.CurrentValue = StringUtil.LTrimStr( (decimal)(A11UsuarioPerfil), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
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
         A14UsuarioAtivo = StringUtil.StrToBool( StringUtil.BoolToStr( A14UsuarioAtivo));
         /*  Sending validation outputs */
         AssignAttri("", false, "A9UsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9UsuarioId), 18, 0, ".", "")));
         AssignAttri("", false, "A10UsuarioNome", StringUtil.RTrim( A10UsuarioNome));
         AssignAttri("", false, "A11UsuarioPerfil", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11UsuarioPerfil), 4, 0, ".", "")));
         cmbUsuarioPerfil.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A11UsuarioPerfil), 4, 0));
         AssignProp("", false, cmbUsuarioPerfil_Internalname, "Values", cmbUsuarioPerfil.ToJavascriptSource(), true);
         AssignAttri("", false, "A16UsuarioEmail", A16UsuarioEmail);
         AssignAttri("", false, "A14UsuarioAtivo", A14UsuarioAtivo);
         AssignAttri("", false, "A173UsuarioFuncaoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A173UsuarioFuncaoId), 18, 0, ".", "")));
         AssignAttri("", false, "A174UsuarioFuncaoNome", StringUtil.RTrim( A174UsuarioFuncaoNome));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z689AreaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z689AreaId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z693AreaUsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z693AreaUsuarioId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z9UsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9UsuarioId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z10UsuarioNome", StringUtil.RTrim( Z10UsuarioNome));
         GxWebStd.gx_hidden_field( context, "Z11UsuarioPerfil", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11UsuarioPerfil), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z16UsuarioEmail", Z16UsuarioEmail);
         GxWebStd.gx_hidden_field( context, "Z14UsuarioAtivo", StringUtil.BoolToStr( Z14UsuarioAtivo));
         GxWebStd.gx_hidden_field( context, "Z173UsuarioFuncaoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z173UsuarioFuncaoId), 18, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z174UsuarioFuncaoNome", StringUtil.RTrim( Z174UsuarioFuncaoNome));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Usuarioid( )
      {
         n173UsuarioFuncaoId = false;
         A11UsuarioPerfil = (short)(Math.Round(NumberUtil.Val( cmbUsuarioPerfil.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbUsuarioPerfil.CurrentValue = StringUtil.LTrimStr( (decimal)(A11UsuarioPerfil), 4, 0);
         /* Using cursor T002L17 */
         pr_default.execute(15, new Object[] {A9UsuarioId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "Usuario", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioId_Internalname;
         }
         A10UsuarioNome = T002L17_A10UsuarioNome[0];
         A11UsuarioPerfil = T002L17_A11UsuarioPerfil[0];
         cmbUsuarioPerfil.CurrentValue = StringUtil.LTrimStr( (decimal)(A11UsuarioPerfil), 4, 0);
         A16UsuarioEmail = T002L17_A16UsuarioEmail[0];
         A14UsuarioAtivo = T002L17_A14UsuarioAtivo[0];
         A173UsuarioFuncaoId = T002L17_A173UsuarioFuncaoId[0];
         n173UsuarioFuncaoId = T002L17_n173UsuarioFuncaoId[0];
         pr_default.close(15);
         /* Using cursor T002L18 */
         pr_default.execute(16, new Object[] {n173UsuarioFuncaoId, A173UsuarioFuncaoId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A173UsuarioFuncaoId) ) )
            {
               GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_ForeignKeyNotFound", ""), context.GetMessage( "SGUsuario Funcao", ""), "", "", "", "", "", "", "", ""), "ForeignKeyNotFound", 1, "USUARIOFUNCAOID");
               AnyError = 1;
            }
         }
         A174UsuarioFuncaoNome = T002L18_A174UsuarioFuncaoNome[0];
         pr_default.close(16);
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
         A14UsuarioAtivo = StringUtil.StrToBool( StringUtil.BoolToStr( A14UsuarioAtivo));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A14UsuarioAtivo',fld:'USUARIOATIVO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A14UsuarioAtivo',fld:'USUARIOATIVO',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A14UsuarioAtivo',fld:'USUARIOATIVO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A14UsuarioAtivo',fld:'USUARIOATIVO',pic:''}]}");
         setEventMetadata("VALID_AREAID","{handler:'Valid_Areaid',iparms:[{av:'A689AreaId',fld:'AREAID',pic:'ZZZZZZZZZZZZZZZZZ9'},{av:'A14UsuarioAtivo',fld:'USUARIOATIVO',pic:''}]");
         setEventMetadata("VALID_AREAID",",oparms:[{av:'A14UsuarioAtivo',fld:'USUARIOATIVO',pic:''}]}");
         setEventMetadata("VALID_AREAUSUARIOID","{handler:'Valid_Areausuarioid',iparms:[{av:'cmbUsuarioPerfil'},{av:'A11UsuarioPerfil',fld:'USUARIOPERFIL',pic:'ZZZ9'},{av:'A689AreaId',fld:'AREAID',pic:'ZZZZZZZZZZZZZZZZZ9'},{av:'A693AreaUsuarioId',fld:'AREAUSUARIOID',pic:'ZZZZZZZZZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A14UsuarioAtivo',fld:'USUARIOATIVO',pic:''}]");
         setEventMetadata("VALID_AREAUSUARIOID",",oparms:[{av:'A9UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZZZZZZZZZ9'},{av:'A10UsuarioNome',fld:'USUARIONOME',pic:''},{av:'cmbUsuarioPerfil'},{av:'A11UsuarioPerfil',fld:'USUARIOPERFIL',pic:'ZZZ9'},{av:'A16UsuarioEmail',fld:'USUARIOEMAIL',pic:''},{av:'A173UsuarioFuncaoId',fld:'USUARIOFUNCAOID',pic:'ZZZZZZZZZZZZZZZZZ9'},{av:'A174UsuarioFuncaoNome',fld:'USUARIOFUNCAONOME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z689AreaId'},{av:'Z693AreaUsuarioId'},{av:'Z9UsuarioId'},{av:'Z10UsuarioNome'},{av:'Z11UsuarioPerfil'},{av:'Z16UsuarioEmail'},{av:'Z14UsuarioAtivo'},{av:'Z173UsuarioFuncaoId'},{av:'Z174UsuarioFuncaoNome'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A14UsuarioAtivo',fld:'USUARIOATIVO',pic:''}]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[{av:'A9UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZZZZZZZZZ9'},{av:'A173UsuarioFuncaoId',fld:'USUARIOFUNCAOID',pic:'ZZZZZZZZZZZZZZZZZ9'},{av:'A10UsuarioNome',fld:'USUARIONOME',pic:''},{av:'cmbUsuarioPerfil'},{av:'A11UsuarioPerfil',fld:'USUARIOPERFIL',pic:'ZZZ9'},{av:'A16UsuarioEmail',fld:'USUARIOEMAIL',pic:''},{av:'A174UsuarioFuncaoNome',fld:'USUARIOFUNCAONOME',pic:''},{av:'A14UsuarioAtivo',fld:'USUARIOATIVO',pic:''}]");
         setEventMetadata("VALID_USUARIOID",",oparms:[{av:'A10UsuarioNome',fld:'USUARIONOME',pic:''},{av:'cmbUsuarioPerfil'},{av:'A11UsuarioPerfil',fld:'USUARIOPERFIL',pic:'ZZZ9'},{av:'A16UsuarioEmail',fld:'USUARIOEMAIL',pic:''},{av:'A173UsuarioFuncaoId',fld:'USUARIOFUNCAOID',pic:'ZZZZZZZZZZZZZZZZZ9'},{av:'A174UsuarioFuncaoNome',fld:'USUARIOFUNCAONOME',pic:''},{av:'A14UsuarioAtivo',fld:'USUARIOATIVO',pic:''}]}");
         setEventMetadata("VALID_USUARIOFUNCAOID","{handler:'Valid_Usuariofuncaoid',iparms:[{av:'A14UsuarioAtivo',fld:'USUARIOATIVO',pic:''}]");
         setEventMetadata("VALID_USUARIOFUNCAOID",",oparms:[{av:'A14UsuarioAtivo',fld:'USUARIOATIVO',pic:''}]}");
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
         pr_default.close(18);
         pr_default.close(15);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A10UsuarioNome = "";
         A174UsuarioFuncaoNome = "";
         A16UsuarioEmail = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z10UsuarioNome = "";
         Z16UsuarioEmail = "";
         Z174UsuarioFuncaoNome = "";
         T002L7_A693AreaUsuarioId = new long[1] ;
         T002L7_A10UsuarioNome = new string[] {""} ;
         T002L7_A174UsuarioFuncaoNome = new string[] {""} ;
         T002L7_A11UsuarioPerfil = new short[1] ;
         T002L7_A16UsuarioEmail = new string[] {""} ;
         T002L7_A14UsuarioAtivo = new bool[] {false} ;
         T002L7_A689AreaId = new long[1] ;
         T002L7_A9UsuarioId = new long[1] ;
         T002L7_A173UsuarioFuncaoId = new long[1] ;
         T002L7_n173UsuarioFuncaoId = new bool[] {false} ;
         T002L4_A689AreaId = new long[1] ;
         T002L5_A10UsuarioNome = new string[] {""} ;
         T002L5_A11UsuarioPerfil = new short[1] ;
         T002L5_A16UsuarioEmail = new string[] {""} ;
         T002L5_A14UsuarioAtivo = new bool[] {false} ;
         T002L5_A173UsuarioFuncaoId = new long[1] ;
         T002L5_n173UsuarioFuncaoId = new bool[] {false} ;
         T002L6_A174UsuarioFuncaoNome = new string[] {""} ;
         T002L8_A689AreaId = new long[1] ;
         T002L9_A10UsuarioNome = new string[] {""} ;
         T002L9_A11UsuarioPerfil = new short[1] ;
         T002L9_A16UsuarioEmail = new string[] {""} ;
         T002L9_A14UsuarioAtivo = new bool[] {false} ;
         T002L9_A173UsuarioFuncaoId = new long[1] ;
         T002L9_n173UsuarioFuncaoId = new bool[] {false} ;
         T002L10_A174UsuarioFuncaoNome = new string[] {""} ;
         T002L11_A689AreaId = new long[1] ;
         T002L11_A693AreaUsuarioId = new long[1] ;
         T002L3_A693AreaUsuarioId = new long[1] ;
         T002L3_A689AreaId = new long[1] ;
         T002L3_A9UsuarioId = new long[1] ;
         sMode102 = "";
         T002L12_A689AreaId = new long[1] ;
         T002L12_A693AreaUsuarioId = new long[1] ;
         T002L13_A689AreaId = new long[1] ;
         T002L13_A693AreaUsuarioId = new long[1] ;
         T002L2_A693AreaUsuarioId = new long[1] ;
         T002L2_A689AreaId = new long[1] ;
         T002L2_A9UsuarioId = new long[1] ;
         T002L17_A10UsuarioNome = new string[] {""} ;
         T002L17_A11UsuarioPerfil = new short[1] ;
         T002L17_A16UsuarioEmail = new string[] {""} ;
         T002L17_A14UsuarioAtivo = new bool[] {false} ;
         T002L17_A173UsuarioFuncaoId = new long[1] ;
         T002L17_n173UsuarioFuncaoId = new bool[] {false} ;
         T002L18_A174UsuarioFuncaoNome = new string[] {""} ;
         T002L19_A689AreaId = new long[1] ;
         T002L19_A693AreaUsuarioId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T002L20_A689AreaId = new long[1] ;
         ZZ10UsuarioNome = "";
         ZZ16UsuarioEmail = "";
         ZZ174UsuarioFuncaoNome = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.areausuario__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areausuario__default(),
            new Object[][] {
                new Object[] {
               T002L2_A693AreaUsuarioId, T002L2_A689AreaId, T002L2_A9UsuarioId
               }
               , new Object[] {
               T002L3_A693AreaUsuarioId, T002L3_A689AreaId, T002L3_A9UsuarioId
               }
               , new Object[] {
               T002L4_A689AreaId
               }
               , new Object[] {
               T002L5_A10UsuarioNome, T002L5_A11UsuarioPerfil, T002L5_A16UsuarioEmail, T002L5_A14UsuarioAtivo, T002L5_A173UsuarioFuncaoId, T002L5_n173UsuarioFuncaoId
               }
               , new Object[] {
               T002L6_A174UsuarioFuncaoNome
               }
               , new Object[] {
               T002L7_A693AreaUsuarioId, T002L7_A10UsuarioNome, T002L7_A174UsuarioFuncaoNome, T002L7_A11UsuarioPerfil, T002L7_A16UsuarioEmail, T002L7_A14UsuarioAtivo, T002L7_A689AreaId, T002L7_A9UsuarioId, T002L7_A173UsuarioFuncaoId, T002L7_n173UsuarioFuncaoId
               }
               , new Object[] {
               T002L8_A689AreaId
               }
               , new Object[] {
               T002L9_A10UsuarioNome, T002L9_A11UsuarioPerfil, T002L9_A16UsuarioEmail, T002L9_A14UsuarioAtivo, T002L9_A173UsuarioFuncaoId, T002L9_n173UsuarioFuncaoId
               }
               , new Object[] {
               T002L10_A174UsuarioFuncaoNome
               }
               , new Object[] {
               T002L11_A689AreaId, T002L11_A693AreaUsuarioId
               }
               , new Object[] {
               T002L12_A689AreaId, T002L12_A693AreaUsuarioId
               }
               , new Object[] {
               T002L13_A689AreaId, T002L13_A693AreaUsuarioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002L17_A10UsuarioNome, T002L17_A11UsuarioPerfil, T002L17_A16UsuarioEmail, T002L17_A14UsuarioAtivo, T002L17_A173UsuarioFuncaoId, T002L17_n173UsuarioFuncaoId
               }
               , new Object[] {
               T002L18_A174UsuarioFuncaoNome
               }
               , new Object[] {
               T002L19_A689AreaId, T002L19_A693AreaUsuarioId
               }
               , new Object[] {
               T002L20_A689AreaId
               }
            }
         );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A11UsuarioPerfil ;
      private short Z11UsuarioPerfil ;
      private short RcdFound102 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ11UsuarioPerfil ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAreaId_Enabled ;
      private int edtAreaUsuarioId_Enabled ;
      private int edtUsuarioId_Enabled ;
      private int edtUsuarioNome_Enabled ;
      private int edtUsuarioFuncaoId_Enabled ;
      private int edtUsuarioFuncaoNome_Enabled ;
      private int edtUsuarioEmail_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z689AreaId ;
      private long Z693AreaUsuarioId ;
      private long Z9UsuarioId ;
      private long A689AreaId ;
      private long A9UsuarioId ;
      private long A173UsuarioFuncaoId ;
      private long A693AreaUsuarioId ;
      private long Z173UsuarioFuncaoId ;
      private long ZZ689AreaId ;
      private long ZZ693AreaUsuarioId ;
      private long ZZ9UsuarioId ;
      private long ZZ173UsuarioFuncaoId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAreaId_Internalname ;
      private string cmbUsuarioPerfil_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtAreaId_Jsonclick ;
      private string edtAreaUsuarioId_Internalname ;
      private string edtAreaUsuarioId_Jsonclick ;
      private string edtUsuarioId_Internalname ;
      private string edtUsuarioId_Jsonclick ;
      private string edtUsuarioNome_Internalname ;
      private string A10UsuarioNome ;
      private string edtUsuarioNome_Jsonclick ;
      private string edtUsuarioFuncaoId_Internalname ;
      private string edtUsuarioFuncaoId_Jsonclick ;
      private string edtUsuarioFuncaoNome_Internalname ;
      private string A174UsuarioFuncaoNome ;
      private string edtUsuarioFuncaoNome_Jsonclick ;
      private string cmbUsuarioPerfil_Jsonclick ;
      private string edtUsuarioEmail_Internalname ;
      private string edtUsuarioEmail_Jsonclick ;
      private string chkUsuarioAtivo_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z10UsuarioNome ;
      private string Z174UsuarioFuncaoNome ;
      private string sMode102 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ10UsuarioNome ;
      private string ZZ174UsuarioFuncaoNome ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n173UsuarioFuncaoId ;
      private bool wbErr ;
      private bool A14UsuarioAtivo ;
      private bool Z14UsuarioAtivo ;
      private bool ZZ14UsuarioAtivo ;
      private string A16UsuarioEmail ;
      private string Z16UsuarioEmail ;
      private string ZZ16UsuarioEmail ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbUsuarioPerfil ;
      private GXCheckbox chkUsuarioAtivo ;
      private IDataStoreProvider pr_default ;
      private long[] T002L7_A693AreaUsuarioId ;
      private string[] T002L7_A10UsuarioNome ;
      private string[] T002L7_A174UsuarioFuncaoNome ;
      private short[] T002L7_A11UsuarioPerfil ;
      private string[] T002L7_A16UsuarioEmail ;
      private bool[] T002L7_A14UsuarioAtivo ;
      private long[] T002L7_A689AreaId ;
      private long[] T002L7_A9UsuarioId ;
      private long[] T002L7_A173UsuarioFuncaoId ;
      private bool[] T002L7_n173UsuarioFuncaoId ;
      private long[] T002L4_A689AreaId ;
      private string[] T002L5_A10UsuarioNome ;
      private short[] T002L5_A11UsuarioPerfil ;
      private string[] T002L5_A16UsuarioEmail ;
      private bool[] T002L5_A14UsuarioAtivo ;
      private long[] T002L5_A173UsuarioFuncaoId ;
      private bool[] T002L5_n173UsuarioFuncaoId ;
      private string[] T002L6_A174UsuarioFuncaoNome ;
      private long[] T002L8_A689AreaId ;
      private string[] T002L9_A10UsuarioNome ;
      private short[] T002L9_A11UsuarioPerfil ;
      private string[] T002L9_A16UsuarioEmail ;
      private bool[] T002L9_A14UsuarioAtivo ;
      private long[] T002L9_A173UsuarioFuncaoId ;
      private bool[] T002L9_n173UsuarioFuncaoId ;
      private string[] T002L10_A174UsuarioFuncaoNome ;
      private long[] T002L11_A689AreaId ;
      private long[] T002L11_A693AreaUsuarioId ;
      private long[] T002L3_A693AreaUsuarioId ;
      private long[] T002L3_A689AreaId ;
      private long[] T002L3_A9UsuarioId ;
      private long[] T002L12_A689AreaId ;
      private long[] T002L12_A693AreaUsuarioId ;
      private long[] T002L13_A689AreaId ;
      private long[] T002L13_A693AreaUsuarioId ;
      private long[] T002L2_A693AreaUsuarioId ;
      private long[] T002L2_A689AreaId ;
      private long[] T002L2_A9UsuarioId ;
      private string[] T002L17_A10UsuarioNome ;
      private short[] T002L17_A11UsuarioPerfil ;
      private string[] T002L17_A16UsuarioEmail ;
      private bool[] T002L17_A14UsuarioAtivo ;
      private long[] T002L17_A173UsuarioFuncaoId ;
      private bool[] T002L17_n173UsuarioFuncaoId ;
      private string[] T002L18_A174UsuarioFuncaoNome ;
      private long[] T002L19_A689AreaId ;
      private long[] T002L19_A693AreaUsuarioId ;
      private long[] T002L20_A689AreaId ;
      private IDataStoreProvider pr_gam ;
   }

   public class areausuario__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class areausuario__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002L2;
        prmT002L2 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0) ,
        new ParDef("@AreaUsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002L3;
        prmT002L3 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0) ,
        new ParDef("@AreaUsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002L4;
        prmT002L4 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0)
        };
        Object[] prmT002L5;
        prmT002L5 = new Object[] {
        new ParDef("@UsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002L6;
        prmT002L6 = new Object[] {
        new ParDef("@UsuarioFuncaoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002L7;
        prmT002L7 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0) ,
        new ParDef("@AreaUsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002L8;
        prmT002L8 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0)
        };
        Object[] prmT002L9;
        prmT002L9 = new Object[] {
        new ParDef("@UsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002L10;
        prmT002L10 = new Object[] {
        new ParDef("@UsuarioFuncaoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002L11;
        prmT002L11 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0) ,
        new ParDef("@AreaUsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002L12;
        prmT002L12 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0) ,
        new ParDef("@AreaUsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002L13;
        prmT002L13 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0) ,
        new ParDef("@AreaUsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002L14;
        prmT002L14 = new Object[] {
        new ParDef("@AreaUsuarioId",GXType.Decimal,18,0) ,
        new ParDef("@AreaId",GXType.Decimal,18,0) ,
        new ParDef("@UsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002L15;
        prmT002L15 = new Object[] {
        new ParDef("@UsuarioId",GXType.Decimal,18,0) ,
        new ParDef("@AreaId",GXType.Decimal,18,0) ,
        new ParDef("@AreaUsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002L16;
        prmT002L16 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0) ,
        new ParDef("@AreaUsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002L17;
        prmT002L17 = new Object[] {
        new ParDef("@UsuarioId",GXType.Decimal,18,0)
        };
        Object[] prmT002L18;
        prmT002L18 = new Object[] {
        new ParDef("@UsuarioFuncaoId",GXType.Decimal,18,0){Nullable=true}
        };
        Object[] prmT002L19;
        prmT002L19 = new Object[] {
        };
        Object[] prmT002L20;
        prmT002L20 = new Object[] {
        new ParDef("@AreaId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002L2", "SELECT [AreaUsuarioId], [AreaId], [UsuarioId] FROM [AreaUsuario] WITH (UPDLOCK) WHERE [AreaId] = @AreaId AND [AreaUsuarioId] = @AreaUsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L3", "SELECT [AreaUsuarioId], [AreaId], [UsuarioId] FROM [AreaUsuario] WHERE [AreaId] = @AreaId AND [AreaUsuarioId] = @AreaUsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L4", "SELECT [AreaId] FROM [Area] WHERE [AreaId] = @AreaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L5", "SELECT [UsuarioNome], [UsuarioPerfil], [UsuarioEmail], [UsuarioAtivo], [UsuarioFuncaoId] AS UsuarioFuncaoId FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L6", "SELECT [FuncaoNome] AS UsuarioFuncaoNome FROM [Funcao] WHERE [FuncaoId] = @UsuarioFuncaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L7", "SELECT TM1.[AreaUsuarioId], T2.[UsuarioNome], T3.[FuncaoNome] AS UsuarioFuncaoNome, T2.[UsuarioPerfil], T2.[UsuarioEmail], T2.[UsuarioAtivo], TM1.[AreaId], TM1.[UsuarioId], T2.[UsuarioFuncaoId] AS UsuarioFuncaoId FROM (([AreaUsuario] TM1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = TM1.[UsuarioId]) LEFT JOIN [Funcao] T3 ON T3.[FuncaoId] = T2.[UsuarioFuncaoId]) WHERE TM1.[AreaId] = @AreaId and TM1.[AreaUsuarioId] = @AreaUsuarioId ORDER BY TM1.[AreaId], TM1.[AreaUsuarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002L7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L8", "SELECT [AreaId] FROM [Area] WHERE [AreaId] = @AreaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L9", "SELECT [UsuarioNome], [UsuarioPerfil], [UsuarioEmail], [UsuarioAtivo], [UsuarioFuncaoId] AS UsuarioFuncaoId FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L10", "SELECT [FuncaoNome] AS UsuarioFuncaoNome FROM [Funcao] WHERE [FuncaoId] = @UsuarioFuncaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L11", "SELECT [AreaId], [AreaUsuarioId] FROM [AreaUsuario] WHERE [AreaId] = @AreaId AND [AreaUsuarioId] = @AreaUsuarioId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002L11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L12", "SELECT TOP 1 [AreaId], [AreaUsuarioId] FROM [AreaUsuario] WHERE ( [AreaId] > @AreaId or [AreaId] = @AreaId and [AreaUsuarioId] > @AreaUsuarioId) ORDER BY [AreaId], [AreaUsuarioId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002L12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002L13", "SELECT TOP 1 [AreaId], [AreaUsuarioId] FROM [AreaUsuario] WHERE ( [AreaId] < @AreaId or [AreaId] = @AreaId and [AreaUsuarioId] < @AreaUsuarioId) ORDER BY [AreaId] DESC, [AreaUsuarioId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002L13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002L14", "INSERT INTO [AreaUsuario]([AreaUsuarioId], [AreaId], [UsuarioId]) VALUES(@AreaUsuarioId, @AreaId, @UsuarioId)", GxErrorMask.GX_NOMASK,prmT002L14)
           ,new CursorDef("T002L15", "UPDATE [AreaUsuario] SET [UsuarioId]=@UsuarioId  WHERE [AreaId] = @AreaId AND [AreaUsuarioId] = @AreaUsuarioId", GxErrorMask.GX_NOMASK,prmT002L15)
           ,new CursorDef("T002L16", "DELETE FROM [AreaUsuario]  WHERE [AreaId] = @AreaId AND [AreaUsuarioId] = @AreaUsuarioId", GxErrorMask.GX_NOMASK,prmT002L16)
           ,new CursorDef("T002L17", "SELECT [UsuarioNome], [UsuarioPerfil], [UsuarioEmail], [UsuarioAtivo], [UsuarioFuncaoId] AS UsuarioFuncaoId FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L18", "SELECT [FuncaoNome] AS UsuarioFuncaoNome FROM [Funcao] WHERE [FuncaoId] = @UsuarioFuncaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L19", "SELECT [AreaId], [AreaUsuarioId] FROM [AreaUsuario] ORDER BY [AreaId], [AreaUsuarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002L19,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L20", "SELECT [AreaId] FROM [Area] WHERE [AreaId] = @AreaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L20,1, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 60);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 60);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 60);
              ((string[]) buf[2])[0] = rslt.getString(3, 60);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((bool[]) buf[5])[0] = rslt.getBool(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 60);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 60);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 60);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 60);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}

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
   public class accesstoken : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         Form.Meta.addItem("description", context.GetMessage( "Access Token", ""), 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAccessTokenToken_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public accesstoken( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public accesstoken( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, context.GetMessage( "Access Token", ""), "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_AccessToken.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AccessToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_AccessToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_AccessToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AccessToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", context.GetMessage( "GX_BtnSelect", ""), bttBtn_select_Jsonclick, 5, context.GetMessage( "GX_BtnSelect", ""), "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_AccessToken.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAccessTokenToken_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAccessTokenToken_Internalname, context.GetMessage( "Token Token", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAccessTokenToken_Internalname, A196AccessTokenToken, StringUtil.RTrim( context.localUtil.Format( A196AccessTokenToken, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAccessTokenToken_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAccessTokenToken_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 1, -1, -1, true, "", "start", true, "", "HLP_AccessToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAccessTokenDuration_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAccessTokenDuration_Internalname, context.GetMessage( "Token Duration", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAccessTokenDuration_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A261AccessTokenDuration), 8, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtAccessTokenDuration_Enabled!=0) ? context.localUtil.Format( (decimal)(A261AccessTokenDuration), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A261AccessTokenDuration), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,gx.thousandSeparator);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAccessTokenDuration_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAccessTokenDuration_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "end", false, "", "HLP_AccessToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAccessTokenValid_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAccessTokenValid_Internalname, context.GetMessage( "Token Valid", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtAccessTokenValid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A262AccessTokenValid), 4, 0, context.GetLanguageProperty( "decimal_point"), "")), StringUtil.LTrim( ((edtAccessTokenValid_Enabled!=0) ? context.localUtil.Format( (decimal)(A262AccessTokenValid), "ZZZ9") : context.localUtil.Format( (decimal)(A262AccessTokenValid), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAccessTokenValid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAccessTokenValid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "end", false, "", "HLP_AccessToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAccessTokenDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAccessTokenDate_Internalname, context.GetMessage( "Token Date", ""), "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAccessTokenDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAccessTokenDate_Internalname, context.localUtil.TToC( A260AccessTokenDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "), context.localUtil.Format( A260AccessTokenDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'"+context.GetLanguageProperty( "date_fmt")+"',5,"+context.GetLanguageProperty( "time_fmt")+",'"+context.GetLanguageProperty( "code")+"',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAccessTokenDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAccessTokenDate_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "end", false, "", "HLP_AccessToken.htm");
         GxWebStd.gx_bitmap( context, edtAccessTokenDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAccessTokenDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_AccessToken.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", context.GetMessage( "GX_BtnEnter", ""), bttBtn_enter_Jsonclick, 5, context.GetMessage( "GX_BtnEnter", ""), "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AccessToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", context.GetMessage( "GX_BtnCancel", ""), bttBtn_cancel_Jsonclick, 1, context.GetMessage( "GX_BtnCancel", ""), "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AccessToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", context.GetMessage( "GX_BtnDelete", ""), bttBtn_delete_Jsonclick, 5, context.GetMessage( "GX_BtnDelete", ""), "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_AccessToken.htm");
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
            Z196AccessTokenToken = cgiGet( "Z196AccessTokenToken");
            Z261AccessTokenDuration = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z261AccessTokenDuration"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Z260AccessTokenDate = context.localUtil.CToT( cgiGet( "Z260AccessTokenDate"), 0);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A196AccessTokenToken = cgiGet( edtAccessTokenToken_Internalname);
            AssignAttri("", false, "A196AccessTokenToken", A196AccessTokenToken);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAccessTokenDuration_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAccessTokenDuration_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")) > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACCESSTOKENDURATION");
               AnyError = 1;
               GX_FocusControl = edtAccessTokenDuration_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A261AccessTokenDuration = 0;
               AssignAttri("", false, "A261AccessTokenDuration", StringUtil.LTrimStr( (decimal)(A261AccessTokenDuration), 8, 0));
            }
            else
            {
               A261AccessTokenDuration = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAccessTokenDuration_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A261AccessTokenDuration", StringUtil.LTrimStr( (decimal)(A261AccessTokenDuration), 8, 0));
            }
            A262AccessTokenValid = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtAccessTokenValid_Internalname), context.GetLanguageProperty( "decimal_point"), context.GetLanguageProperty( "thousand_sep")), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A262AccessTokenValid", StringUtil.LTrimStr( (decimal)(A262AccessTokenValid), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtAccessTokenDate_Internalname), (short)(DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt"))), (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0))) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {context.GetMessage( "Access Token Date", "")}), 1, "ACCESSTOKENDATE");
               AnyError = 1;
               GX_FocusControl = edtAccessTokenDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A260AccessTokenDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A260AccessTokenDate", context.localUtil.TToC( A260AccessTokenDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
            else
            {
               A260AccessTokenDate = context.localUtil.CToT( cgiGet( edtAccessTokenDate_Internalname));
               AssignAttri("", false, "A260AccessTokenDate", context.localUtil.TToC( A260AccessTokenDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            }
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
               A196AccessTokenToken = GetPar( "AccessTokenToken");
               AssignAttri("", false, "A196AccessTokenToken", A196AccessTokenToken);
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
               InitAll0V37( ) ;
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
         DisableAttributes0V37( ) ;
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

      protected void ResetCaption0V0( )
      {
      }

      protected void ZM0V37( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z261AccessTokenDuration = T000V3_A261AccessTokenDuration[0];
               Z260AccessTokenDate = T000V3_A260AccessTokenDate[0];
            }
            else
            {
               Z261AccessTokenDuration = A261AccessTokenDuration;
               Z260AccessTokenDate = A260AccessTokenDate;
            }
         }
         if ( GX_JID == -3 )
         {
            Z196AccessTokenToken = A196AccessTokenToken;
            Z261AccessTokenDuration = A261AccessTokenDuration;
            Z260AccessTokenDate = A260AccessTokenDate;
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

      protected void Load0V37( )
      {
         /* Using cursor T000V4 */
         pr_default.execute(2, new Object[] {A196AccessTokenToken});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound37 = 1;
            A261AccessTokenDuration = T000V4_A261AccessTokenDuration[0];
            AssignAttri("", false, "A261AccessTokenDuration", StringUtil.LTrimStr( (decimal)(A261AccessTokenDuration), 8, 0));
            A260AccessTokenDate = T000V4_A260AccessTokenDate[0];
            AssignAttri("", false, "A260AccessTokenDate", context.localUtil.TToC( A260AccessTokenDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            ZM0V37( -3) ;
         }
         pr_default.close(2);
         OnLoadActions0V37( ) ;
      }

      protected void OnLoadActions0V37( )
      {
         if ( DateTimeUtil.TAdd( A260AccessTokenDate, A261AccessTokenDuration) > DateTimeUtil.Now( context) )
         {
            A262AccessTokenValid = (short)(Convert.ToInt16(true));
            AssignAttri("", false, "A262AccessTokenValid", StringUtil.LTrimStr( (decimal)(A262AccessTokenValid), 4, 0));
         }
         else
         {
            if ( DateTimeUtil.TAdd( A260AccessTokenDate, A261AccessTokenDuration) <= DateTimeUtil.Now( context) )
            {
               A262AccessTokenValid = (short)(Convert.ToInt16(false));
               AssignAttri("", false, "A262AccessTokenValid", StringUtil.LTrimStr( (decimal)(A262AccessTokenValid), 4, 0));
            }
            else
            {
               A262AccessTokenValid = 0;
               AssignAttri("", false, "A262AccessTokenValid", StringUtil.LTrimStr( (decimal)(A262AccessTokenValid), 4, 0));
            }
         }
      }

      protected void CheckExtendedTable0V37( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( DateTimeUtil.TAdd( A260AccessTokenDate, A261AccessTokenDuration) > DateTimeUtil.Now( context) )
         {
            A262AccessTokenValid = (short)(Convert.ToInt16(true));
            AssignAttri("", false, "A262AccessTokenValid", StringUtil.LTrimStr( (decimal)(A262AccessTokenValid), 4, 0));
         }
         else
         {
            if ( DateTimeUtil.TAdd( A260AccessTokenDate, A261AccessTokenDuration) <= DateTimeUtil.Now( context) )
            {
               A262AccessTokenValid = (short)(Convert.ToInt16(false));
               AssignAttri("", false, "A262AccessTokenValid", StringUtil.LTrimStr( (decimal)(A262AccessTokenValid), 4, 0));
            }
            else
            {
               A262AccessTokenValid = 0;
               AssignAttri("", false, "A262AccessTokenValid", StringUtil.LTrimStr( (decimal)(A262AccessTokenValid), 4, 0));
            }
         }
         if ( ! ( (DateTime.MinValue==A260AccessTokenDate) || ( A260AccessTokenDate >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Access Token Date", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "ACCESSTOKENDATE");
            AnyError = 1;
            GX_FocusControl = edtAccessTokenDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0V37( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0V37( )
      {
         /* Using cursor T000V5 */
         pr_default.execute(3, new Object[] {A196AccessTokenToken});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound37 = 1;
         }
         else
         {
            RcdFound37 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000V3 */
         pr_default.execute(1, new Object[] {A196AccessTokenToken});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0V37( 3) ;
            RcdFound37 = 1;
            A196AccessTokenToken = T000V3_A196AccessTokenToken[0];
            AssignAttri("", false, "A196AccessTokenToken", A196AccessTokenToken);
            A261AccessTokenDuration = T000V3_A261AccessTokenDuration[0];
            AssignAttri("", false, "A261AccessTokenDuration", StringUtil.LTrimStr( (decimal)(A261AccessTokenDuration), 8, 0));
            A260AccessTokenDate = T000V3_A260AccessTokenDate[0];
            AssignAttri("", false, "A260AccessTokenDate", context.localUtil.TToC( A260AccessTokenDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
            Z196AccessTokenToken = A196AccessTokenToken;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0V37( ) ;
            if ( AnyError == 1 )
            {
               RcdFound37 = 0;
               InitializeNonKey0V37( ) ;
            }
            Gx_mode = sMode37;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound37 = 0;
            InitializeNonKey0V37( ) ;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode37;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0V37( ) ;
         if ( RcdFound37 == 0 )
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
         RcdFound37 = 0;
         /* Using cursor T000V6 */
         pr_default.execute(4, new Object[] {A196AccessTokenToken});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000V6_A196AccessTokenToken[0], A196AccessTokenToken) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000V6_A196AccessTokenToken[0], A196AccessTokenToken) > 0 ) ) )
            {
               A196AccessTokenToken = T000V6_A196AccessTokenToken[0];
               AssignAttri("", false, "A196AccessTokenToken", A196AccessTokenToken);
               RcdFound37 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound37 = 0;
         /* Using cursor T000V7 */
         pr_default.execute(5, new Object[] {A196AccessTokenToken});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000V7_A196AccessTokenToken[0], A196AccessTokenToken) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000V7_A196AccessTokenToken[0], A196AccessTokenToken) < 0 ) ) )
            {
               A196AccessTokenToken = T000V7_A196AccessTokenToken[0];
               AssignAttri("", false, "A196AccessTokenToken", A196AccessTokenToken);
               RcdFound37 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0V37( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAccessTokenToken_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0V37( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound37 == 1 )
            {
               if ( StringUtil.StrCmp(A196AccessTokenToken, Z196AccessTokenToken) != 0 )
               {
                  A196AccessTokenToken = Z196AccessTokenToken;
                  AssignAttri("", false, "A196AccessTokenToken", A196AccessTokenToken);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ACCESSTOKENTOKEN");
                  AnyError = 1;
                  GX_FocusControl = edtAccessTokenToken_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAccessTokenToken_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0V37( ) ;
                  GX_FocusControl = edtAccessTokenToken_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A196AccessTokenToken, Z196AccessTokenToken) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAccessTokenToken_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0V37( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ACCESSTOKENTOKEN");
                     AnyError = 1;
                     GX_FocusControl = edtAccessTokenToken_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAccessTokenToken_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0V37( ) ;
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
         if ( StringUtil.StrCmp(A196AccessTokenToken, Z196AccessTokenToken) != 0 )
         {
            A196AccessTokenToken = Z196AccessTokenToken;
            AssignAttri("", false, "A196AccessTokenToken", A196AccessTokenToken);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ACCESSTOKENTOKEN");
            AnyError = 1;
            GX_FocusControl = edtAccessTokenToken_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAccessTokenToken_Internalname;
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
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ACCESSTOKENTOKEN");
            AnyError = 1;
            GX_FocusControl = edtAccessTokenToken_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAccessTokenDuration_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0V37( ) ;
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAccessTokenDuration_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0V37( ) ;
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
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAccessTokenDuration_Internalname;
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
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAccessTokenDuration_Internalname;
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
         ScanStart0V37( ) ;
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound37 != 0 )
            {
               ScanNext0V37( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAccessTokenDuration_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0V37( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0V37( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000V2 */
            pr_default.execute(0, new Object[] {A196AccessTokenToken});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AccessToken"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z261AccessTokenDuration != T000V2_A261AccessTokenDuration[0] ) || ( Z260AccessTokenDate != T000V2_A260AccessTokenDate[0] ) )
            {
               if ( Z261AccessTokenDuration != T000V2_A261AccessTokenDuration[0] )
               {
                  GXUtil.WriteLog("accesstoken:[seudo value changed for attri]"+"AccessTokenDuration");
                  GXUtil.WriteLogRaw("Old: ",Z261AccessTokenDuration);
                  GXUtil.WriteLogRaw("Current: ",T000V2_A261AccessTokenDuration[0]);
               }
               if ( Z260AccessTokenDate != T000V2_A260AccessTokenDate[0] )
               {
                  GXUtil.WriteLog("accesstoken:[seudo value changed for attri]"+"AccessTokenDate");
                  GXUtil.WriteLogRaw("Old: ",Z260AccessTokenDate);
                  GXUtil.WriteLogRaw("Current: ",T000V2_A260AccessTokenDate[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AccessToken"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0V37( )
      {
         BeforeValidate0V37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0V37( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0V37( 0) ;
            CheckOptimisticConcurrency0V37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0V37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0V37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000V8 */
                     pr_default.execute(6, new Object[] {A196AccessTokenToken, A261AccessTokenDuration, A260AccessTokenDate});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("AccessToken");
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption0V0( ) ;
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
               Load0V37( ) ;
            }
            EndLevel0V37( ) ;
         }
         CloseExtendedTableCursors0V37( ) ;
      }

      protected void Update0V37( )
      {
         BeforeValidate0V37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0V37( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0V37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0V37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0V37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000V9 */
                     pr_default.execute(7, new Object[] {A261AccessTokenDuration, A260AccessTokenDate, A196AccessTokenToken});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("AccessToken");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AccessToken"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0V37( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0V0( ) ;
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
            EndLevel0V37( ) ;
         }
         CloseExtendedTableCursors0V37( ) ;
      }

      protected void DeferredUpdate0V37( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0V37( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0V37( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0V37( ) ;
            AfterConfirm0V37( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0V37( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000V10 */
                  pr_default.execute(8, new Object[] {A196AccessTokenToken});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("AccessToken");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound37 == 0 )
                        {
                           InitAll0V37( ) ;
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
                        ResetCaption0V0( ) ;
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
         sMode37 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0V37( ) ;
         Gx_mode = sMode37;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0V37( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( DateTimeUtil.TAdd( A260AccessTokenDate, A261AccessTokenDuration) > DateTimeUtil.Now( context) )
            {
               A262AccessTokenValid = (short)(Convert.ToInt16(true));
               AssignAttri("", false, "A262AccessTokenValid", StringUtil.LTrimStr( (decimal)(A262AccessTokenValid), 4, 0));
            }
            else
            {
               if ( DateTimeUtil.TAdd( A260AccessTokenDate, A261AccessTokenDuration) <= DateTimeUtil.Now( context) )
               {
                  A262AccessTokenValid = (short)(Convert.ToInt16(false));
                  AssignAttri("", false, "A262AccessTokenValid", StringUtil.LTrimStr( (decimal)(A262AccessTokenValid), 4, 0));
               }
               else
               {
                  A262AccessTokenValid = 0;
                  AssignAttri("", false, "A262AccessTokenValid", StringUtil.LTrimStr( (decimal)(A262AccessTokenValid), 4, 0));
               }
            }
         }
      }

      protected void EndLevel0V37( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0V37( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("accesstoken",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0V0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("accesstoken",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0V37( )
      {
         /* Using cursor T000V11 */
         pr_default.execute(9);
         RcdFound37 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound37 = 1;
            A196AccessTokenToken = T000V11_A196AccessTokenToken[0];
            AssignAttri("", false, "A196AccessTokenToken", A196AccessTokenToken);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0V37( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound37 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound37 = 1;
            A196AccessTokenToken = T000V11_A196AccessTokenToken[0];
            AssignAttri("", false, "A196AccessTokenToken", A196AccessTokenToken);
         }
      }

      protected void ScanEnd0V37( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0V37( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0V37( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0V37( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0V37( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0V37( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0V37( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0V37( )
      {
         edtAccessTokenToken_Enabled = 0;
         AssignProp("", false, edtAccessTokenToken_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAccessTokenToken_Enabled), 5, 0), true);
         edtAccessTokenDuration_Enabled = 0;
         AssignProp("", false, edtAccessTokenDuration_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAccessTokenDuration_Enabled), 5, 0), true);
         edtAccessTokenValid_Enabled = 0;
         AssignProp("", false, edtAccessTokenValid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAccessTokenValid_Enabled), 5, 0), true);
         edtAccessTokenDate_Enabled = 0;
         AssignProp("", false, edtAccessTokenDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAccessTokenDate_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0V37( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0V0( )
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 835140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 835140), false, true);
         context.AddJavascriptSource("calendar-"+StringUtil.Substring( context.GetLanguageProperty( "culture"), 1, 2)+".js", "?"+context.GetBuildNumber( 835140), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("accesstoken.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z196AccessTokenToken", Z196AccessTokenToken);
         GxWebStd.gx_hidden_field( context, "Z261AccessTokenDuration", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z261AccessTokenDuration), 8, 0, context.GetLanguageProperty( "decimal_point"), "")));
         GxWebStd.gx_hidden_field( context, "Z260AccessTokenDate", context.localUtil.TToC( Z260AccessTokenDate, 10, 8, 0, 0, "/", ":", " "));
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
         return formatLink("accesstoken.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AccessToken" ;
      }

      public override string GetPgmdesc( )
      {
         return context.GetMessage( "Access Token", "") ;
      }

      protected void InitializeNonKey0V37( )
      {
         A262AccessTokenValid = 0;
         AssignAttri("", false, "A262AccessTokenValid", StringUtil.LTrimStr( (decimal)(A262AccessTokenValid), 4, 0));
         A261AccessTokenDuration = 0;
         AssignAttri("", false, "A261AccessTokenDuration", StringUtil.LTrimStr( (decimal)(A261AccessTokenDuration), 8, 0));
         A260AccessTokenDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A260AccessTokenDate", context.localUtil.TToC( A260AccessTokenDate, 8, 5, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         Z261AccessTokenDuration = 0;
         Z260AccessTokenDate = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll0V37( )
      {
         A196AccessTokenToken = "";
         AssignAttri("", false, "A196AccessTokenToken", A196AccessTokenToken);
         InitializeNonKey0V37( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20246181546715", true, true);
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
         context.AddJavascriptSource("accesstoken.js", "?20246181546715", false, true);
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
         edtAccessTokenToken_Internalname = "ACCESSTOKENTOKEN";
         edtAccessTokenDuration_Internalname = "ACCESSTOKENDURATION";
         edtAccessTokenValid_Internalname = "ACCESSTOKENVALID";
         edtAccessTokenDate_Internalname = "ACCESSTOKENDATE";
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
         Form.Caption = context.GetMessage( "Access Token", "");
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtAccessTokenDate_Jsonclick = "";
         edtAccessTokenDate_Enabled = 1;
         edtAccessTokenValid_Jsonclick = "";
         edtAccessTokenValid_Enabled = 0;
         edtAccessTokenDuration_Jsonclick = "";
         edtAccessTokenDuration_Enabled = 1;
         edtAccessTokenToken_Jsonclick = "";
         edtAccessTokenToken_Enabled = 1;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtAccessTokenDuration_Internalname;
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

      public void Valid_Accesstokentoken( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A261AccessTokenDuration", StringUtil.LTrim( StringUtil.NToC( (decimal)(A261AccessTokenDuration), 8, 0, ".", "")));
         AssignAttri("", false, "A260AccessTokenDate", context.localUtil.TToC( A260AccessTokenDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         AssignAttri("", false, "A262AccessTokenValid", StringUtil.LTrim( StringUtil.NToC( (decimal)(A262AccessTokenValid), 4, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z196AccessTokenToken", Z196AccessTokenToken);
         GxWebStd.gx_hidden_field( context, "Z261AccessTokenDuration", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z261AccessTokenDuration), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z260AccessTokenDate", context.localUtil.TToC( Z260AccessTokenDate, 10, 8, (short)(((StringUtil.StrCmp(context.GetLanguageProperty( "time_fmt"), "12")==0) ? 1 : 0)), (short)(DateTimeUtil.MapDateTimeFormat( context.GetLanguageProperty( "date_fmt"))), "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z262AccessTokenValid", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z262AccessTokenValid), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Accesstokendate( )
      {
         if ( ! ( (DateTime.MinValue==A260AccessTokenDate) || ( A260AccessTokenDate >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Access Token Date", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "ACCESSTOKENDATE");
            AnyError = 1;
            GX_FocusControl = edtAccessTokenDate_Internalname;
         }
         if ( DateTimeUtil.TAdd( A260AccessTokenDate, A261AccessTokenDuration) > DateTimeUtil.Now( context) )
         {
            A262AccessTokenValid = (short)(Convert.ToInt16(true));
         }
         else
         {
            if ( DateTimeUtil.TAdd( A260AccessTokenDate, A261AccessTokenDuration) <= DateTimeUtil.Now( context) )
            {
               A262AccessTokenValid = (short)(Convert.ToInt16(false));
            }
            else
            {
               A262AccessTokenValid = 0;
            }
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A262AccessTokenValid", StringUtil.LTrim( StringUtil.NToC( (decimal)(A262AccessTokenValid), 4, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_ACCESSTOKENTOKEN","{handler:'Valid_Accesstokentoken',iparms:[{av:'A196AccessTokenToken',fld:'ACCESSTOKENTOKEN',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ACCESSTOKENTOKEN",",oparms:[{av:'A261AccessTokenDuration',fld:'ACCESSTOKENDURATION',pic:'ZZZZZZZ9'},{av:'A260AccessTokenDate',fld:'ACCESSTOKENDATE',pic:'99/99/99 99:99'},{av:'A262AccessTokenValid',fld:'ACCESSTOKENVALID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z196AccessTokenToken'},{av:'Z261AccessTokenDuration'},{av:'Z260AccessTokenDate'},{av:'Z262AccessTokenValid'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_ACCESSTOKENDURATION","{handler:'Valid_Accesstokenduration',iparms:[]");
         setEventMetadata("VALID_ACCESSTOKENDURATION",",oparms:[]}");
         setEventMetadata("VALID_ACCESSTOKENDATE","{handler:'Valid_Accesstokendate',iparms:[{av:'A260AccessTokenDate',fld:'ACCESSTOKENDATE',pic:'99/99/99 99:99'},{av:'A261AccessTokenDuration',fld:'ACCESSTOKENDURATION',pic:'ZZZZZZZ9'},{av:'A262AccessTokenValid',fld:'ACCESSTOKENVALID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_ACCESSTOKENDATE",",oparms:[{av:'A262AccessTokenValid',fld:'ACCESSTOKENVALID',pic:'ZZZ9'}]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z196AccessTokenToken = "";
         Z260AccessTokenDate = (DateTime)(DateTime.MinValue);
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
         A196AccessTokenToken = "";
         A260AccessTokenDate = (DateTime)(DateTime.MinValue);
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
         T000V4_A196AccessTokenToken = new string[] {""} ;
         T000V4_A261AccessTokenDuration = new int[1] ;
         T000V4_A260AccessTokenDate = new DateTime[] {DateTime.MinValue} ;
         T000V5_A196AccessTokenToken = new string[] {""} ;
         T000V3_A196AccessTokenToken = new string[] {""} ;
         T000V3_A261AccessTokenDuration = new int[1] ;
         T000V3_A260AccessTokenDate = new DateTime[] {DateTime.MinValue} ;
         sMode37 = "";
         T000V6_A196AccessTokenToken = new string[] {""} ;
         T000V7_A196AccessTokenToken = new string[] {""} ;
         T000V2_A196AccessTokenToken = new string[] {""} ;
         T000V2_A261AccessTokenDuration = new int[1] ;
         T000V2_A260AccessTokenDate = new DateTime[] {DateTime.MinValue} ;
         T000V11_A196AccessTokenToken = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ196AccessTokenToken = "";
         ZZ260AccessTokenDate = (DateTime)(DateTime.MinValue);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.accesstoken__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.accesstoken__default(),
            new Object[][] {
                new Object[] {
               T000V2_A196AccessTokenToken, T000V2_A261AccessTokenDuration, T000V2_A260AccessTokenDate
               }
               , new Object[] {
               T000V3_A196AccessTokenToken, T000V3_A261AccessTokenDuration, T000V3_A260AccessTokenDate
               }
               , new Object[] {
               T000V4_A196AccessTokenToken, T000V4_A261AccessTokenDuration, T000V4_A260AccessTokenDate
               }
               , new Object[] {
               T000V5_A196AccessTokenToken
               }
               , new Object[] {
               T000V6_A196AccessTokenToken
               }
               , new Object[] {
               T000V7_A196AccessTokenToken
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000V11_A196AccessTokenToken
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
      private short A262AccessTokenValid ;
      private short RcdFound37 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short Z262AccessTokenValid ;
      private short ZZ262AccessTokenValid ;
      private int Z261AccessTokenDuration ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAccessTokenToken_Enabled ;
      private int A261AccessTokenDuration ;
      private int edtAccessTokenDuration_Enabled ;
      private int edtAccessTokenValid_Enabled ;
      private int edtAccessTokenDate_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ261AccessTokenDuration ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAccessTokenToken_Internalname ;
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
      private string edtAccessTokenToken_Jsonclick ;
      private string edtAccessTokenDuration_Internalname ;
      private string edtAccessTokenDuration_Jsonclick ;
      private string edtAccessTokenValid_Internalname ;
      private string edtAccessTokenValid_Jsonclick ;
      private string edtAccessTokenDate_Internalname ;
      private string edtAccessTokenDate_Jsonclick ;
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
      private string sMode37 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z260AccessTokenDate ;
      private DateTime A260AccessTokenDate ;
      private DateTime ZZ260AccessTokenDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z196AccessTokenToken ;
      private string A196AccessTokenToken ;
      private string ZZ196AccessTokenToken ;
      private GXWebForm Form ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000V4_A196AccessTokenToken ;
      private int[] T000V4_A261AccessTokenDuration ;
      private DateTime[] T000V4_A260AccessTokenDate ;
      private string[] T000V5_A196AccessTokenToken ;
      private string[] T000V3_A196AccessTokenToken ;
      private int[] T000V3_A261AccessTokenDuration ;
      private DateTime[] T000V3_A260AccessTokenDate ;
      private string[] T000V6_A196AccessTokenToken ;
      private string[] T000V7_A196AccessTokenToken ;
      private string[] T000V2_A196AccessTokenToken ;
      private int[] T000V2_A261AccessTokenDuration ;
      private DateTime[] T000V2_A260AccessTokenDate ;
      private string[] T000V11_A196AccessTokenToken ;
      private IDataStoreProvider pr_gam ;
   }

   public class accesstoken__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class accesstoken__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000V2;
        prmT000V2 = new Object[] {
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0)
        };
        Object[] prmT000V3;
        prmT000V3 = new Object[] {
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0)
        };
        Object[] prmT000V4;
        prmT000V4 = new Object[] {
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0)
        };
        Object[] prmT000V5;
        prmT000V5 = new Object[] {
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0)
        };
        Object[] prmT000V6;
        prmT000V6 = new Object[] {
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0)
        };
        Object[] prmT000V7;
        prmT000V7 = new Object[] {
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0)
        };
        Object[] prmT000V8;
        prmT000V8 = new Object[] {
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0) ,
        new ParDef("@AccessTokenDuration",GXType.Int32,8,0) ,
        new ParDef("@AccessTokenDate",GXType.DateTime,8,5)
        };
        Object[] prmT000V9;
        prmT000V9 = new Object[] {
        new ParDef("@AccessTokenDuration",GXType.Int32,8,0) ,
        new ParDef("@AccessTokenDate",GXType.DateTime,8,5) ,
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0)
        };
        Object[] prmT000V10;
        prmT000V10 = new Object[] {
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0)
        };
        Object[] prmT000V11;
        prmT000V11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000V2", "SELECT [AccessTokenToken], [AccessTokenDuration], [AccessTokenDate] FROM [AccessToken] WITH (UPDLOCK) WHERE [AccessTokenToken] = @AccessTokenToken ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V3", "SELECT [AccessTokenToken], [AccessTokenDuration], [AccessTokenDate] FROM [AccessToken] WHERE [AccessTokenToken] = @AccessTokenToken ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V4", "SELECT TM1.[AccessTokenToken], TM1.[AccessTokenDuration], TM1.[AccessTokenDate] FROM [AccessToken] TM1 WHERE TM1.[AccessTokenToken] = @AccessTokenToken ORDER BY TM1.[AccessTokenToken]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000V4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V5", "SELECT [AccessTokenToken] FROM [AccessToken] WHERE [AccessTokenToken] = @AccessTokenToken  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000V5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V6", "SELECT TOP 1 [AccessTokenToken] FROM [AccessToken] WHERE ( [AccessTokenToken] > @AccessTokenToken) ORDER BY [AccessTokenToken]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000V6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V7", "SELECT TOP 1 [AccessTokenToken] FROM [AccessToken] WHERE ( [AccessTokenToken] < @AccessTokenToken) ORDER BY [AccessTokenToken] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000V7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V8", "INSERT INTO [AccessToken]([AccessTokenToken], [AccessTokenDuration], [AccessTokenDate]) VALUES(@AccessTokenToken, @AccessTokenDuration, @AccessTokenDate)", GxErrorMask.GX_NOMASK,prmT000V8)
           ,new CursorDef("T000V9", "UPDATE [AccessToken] SET [AccessTokenDuration]=@AccessTokenDuration, [AccessTokenDate]=@AccessTokenDate  WHERE [AccessTokenToken] = @AccessTokenToken", GxErrorMask.GX_NOMASK,prmT000V9)
           ,new CursorDef("T000V10", "DELETE FROM [AccessToken]  WHERE [AccessTokenToken] = @AccessTokenToken", GxErrorMask.GX_NOMASK,prmT000V10)
           ,new CursorDef("T000V11", "SELECT [AccessTokenToken] FROM [AccessToken] ORDER BY [AccessTokenToken]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000V11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}

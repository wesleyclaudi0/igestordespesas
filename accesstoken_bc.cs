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
   public class accesstoken_bc : GXHttpHandler, IGxSilentTrn
   {
      public accesstoken_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public accesstoken_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0V37( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0V37( ) ;
         standaloneModal( ) ;
         AddRow0V37( ) ;
         Gx_mode = "INS";
         return  ;
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
               Z196AccessTokenToken = A196AccessTokenToken;
               SetMode( "UPD") ;
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

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_0V0( )
      {
         BeforeValidate0V37( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0V37( ) ;
            }
            else
            {
               CheckExtendedTable0V37( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0V37( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0V37( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z261AccessTokenDuration = A261AccessTokenDuration;
            Z260AccessTokenDate = A260AccessTokenDate;
            Z262AccessTokenValid = A262AccessTokenValid;
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
      }

      protected void Load0V37( )
      {
         /* Using cursor BC000V4 */
         pr_default.execute(2, new Object[] {A196AccessTokenToken});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound37 = 1;
            A261AccessTokenDuration = BC000V4_A261AccessTokenDuration[0];
            A260AccessTokenDate = BC000V4_A260AccessTokenDate[0];
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
      }

      protected void CheckExtendedTable0V37( )
      {
         standaloneModal( ) ;
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
         if ( ! ( (DateTime.MinValue==A260AccessTokenDate) || ( A260AccessTokenDate >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem(StringUtil.Format( context.GetMessage( "GXSPC_OutOfRange", ""), context.GetMessage( "Access Token Date", ""), "", "", "", "", "", "", "", ""), "OutOfRange", 1, "");
            AnyError = 1;
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
         /* Using cursor BC000V5 */
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
         /* Using cursor BC000V3 */
         pr_default.execute(1, new Object[] {A196AccessTokenToken});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0V37( 3) ;
            RcdFound37 = 1;
            A196AccessTokenToken = BC000V3_A196AccessTokenToken[0];
            A261AccessTokenDuration = BC000V3_A261AccessTokenDuration[0];
            A260AccessTokenDate = BC000V3_A260AccessTokenDate[0];
            Z196AccessTokenToken = A196AccessTokenToken;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0V37( ) ;
            if ( AnyError == 1 )
            {
               RcdFound37 = 0;
               InitializeNonKey0V37( ) ;
            }
            Gx_mode = sMode37;
         }
         else
         {
            RcdFound37 = 0;
            InitializeNonKey0V37( ) ;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode37;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0V37( ) ;
         if ( RcdFound37 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_0V0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0V37( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000V2 */
            pr_default.execute(0, new Object[] {A196AccessTokenToken});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AccessToken"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z261AccessTokenDuration != BC000V2_A261AccessTokenDuration[0] ) || ( Z260AccessTokenDate != BC000V2_A260AccessTokenDate[0] ) )
            {
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
                     /* Using cursor BC000V6 */
                     pr_default.execute(4, new Object[] {A196AccessTokenToken, A261AccessTokenDuration, A260AccessTokenDate});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("AccessToken");
                     if ( (pr_default.getStatus(4) == 1) )
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
                     /* Using cursor BC000V7 */
                     pr_default.execute(5, new Object[] {A261AccessTokenDuration, A260AccessTokenDate, A196AccessTokenToken});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("AccessToken");
                     if ( (pr_default.getStatus(5) == 103) )
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
                  /* Using cursor BC000V8 */
                  pr_default.execute(6, new Object[] {A196AccessTokenToken});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("AccessToken");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
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
         EndLevel0V37( ) ;
         Gx_mode = sMode37;
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
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0V37( )
      {
         /* Using cursor BC000V9 */
         pr_default.execute(7, new Object[] {A196AccessTokenToken});
         RcdFound37 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound37 = 1;
            A196AccessTokenToken = BC000V9_A196AccessTokenToken[0];
            A261AccessTokenDuration = BC000V9_A261AccessTokenDuration[0];
            A260AccessTokenDate = BC000V9_A260AccessTokenDate[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0V37( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound37 = 0;
         ScanKeyLoad0V37( ) ;
      }

      protected void ScanKeyLoad0V37( )
      {
         sMode37 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound37 = 1;
            A196AccessTokenToken = BC000V9_A196AccessTokenToken[0];
            A261AccessTokenDuration = BC000V9_A261AccessTokenDuration[0];
            A260AccessTokenDate = BC000V9_A260AccessTokenDate[0];
         }
         Gx_mode = sMode37;
      }

      protected void ScanKeyEnd0V37( )
      {
         pr_default.close(7);
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
      }

      protected void send_integrity_lvl_hashes0V37( )
      {
      }

      protected void AddRow0V37( )
      {
         VarsToRow37( bcAccessToken) ;
      }

      protected void ReadRow0V37( )
      {
         RowToVars37( bcAccessToken, 1) ;
      }

      protected void InitializeNonKey0V37( )
      {
         A262AccessTokenValid = 0;
         A261AccessTokenDuration = 0;
         A260AccessTokenDate = (DateTime)(DateTime.MinValue);
         Z261AccessTokenDuration = 0;
         Z260AccessTokenDate = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll0V37( )
      {
         A196AccessTokenToken = "";
         InitializeNonKey0V37( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow37( SdtAccessToken obj37 )
      {
         obj37.gxTpr_Mode = Gx_mode;
         obj37.gxTpr_Accesstokenvalid = A262AccessTokenValid;
         obj37.gxTpr_Accesstokenduration = A261AccessTokenDuration;
         obj37.gxTpr_Accesstokendate = A260AccessTokenDate;
         obj37.gxTpr_Accesstokentoken = A196AccessTokenToken;
         obj37.gxTpr_Accesstokentoken_Z = Z196AccessTokenToken;
         obj37.gxTpr_Accesstokenduration_Z = Z261AccessTokenDuration;
         obj37.gxTpr_Accesstokenvalid_Z = Z262AccessTokenValid;
         obj37.gxTpr_Accesstokendate_Z = Z260AccessTokenDate;
         obj37.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow37( SdtAccessToken obj37 )
      {
         obj37.gxTpr_Accesstokentoken = A196AccessTokenToken;
         return  ;
      }

      public void RowToVars37( SdtAccessToken obj37 ,
                               int forceLoad )
      {
         Gx_mode = obj37.gxTpr_Mode;
         A262AccessTokenValid = obj37.gxTpr_Accesstokenvalid;
         A261AccessTokenDuration = obj37.gxTpr_Accesstokenduration;
         A260AccessTokenDate = obj37.gxTpr_Accesstokendate;
         A196AccessTokenToken = obj37.gxTpr_Accesstokentoken;
         Z196AccessTokenToken = obj37.gxTpr_Accesstokentoken_Z;
         Z261AccessTokenDuration = obj37.gxTpr_Accesstokenduration_Z;
         Z262AccessTokenValid = obj37.gxTpr_Accesstokenvalid_Z;
         Z260AccessTokenDate = obj37.gxTpr_Accesstokendate_Z;
         Gx_mode = obj37.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A196AccessTokenToken = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0V37( ) ;
         ScanKeyStart0V37( ) ;
         if ( RcdFound37 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z196AccessTokenToken = A196AccessTokenToken;
         }
         ZM0V37( -3) ;
         OnLoadActions0V37( ) ;
         AddRow0V37( ) ;
         ScanKeyEnd0V37( ) ;
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars37( bcAccessToken, 0) ;
         ScanKeyStart0V37( ) ;
         if ( RcdFound37 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z196AccessTokenToken = A196AccessTokenToken;
         }
         ZM0V37( -3) ;
         OnLoadActions0V37( ) ;
         AddRow0V37( ) ;
         ScanKeyEnd0V37( ) ;
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0V37( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0V37( ) ;
         }
         else
         {
            if ( RcdFound37 == 1 )
            {
               if ( StringUtil.StrCmp(A196AccessTokenToken, Z196AccessTokenToken) != 0 )
               {
                  A196AccessTokenToken = Z196AccessTokenToken;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update0V37( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( StringUtil.StrCmp(A196AccessTokenToken, Z196AccessTokenToken) != 0 )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0V37( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0V37( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars37( bcAccessToken, 1) ;
         SaveImpl( ) ;
         VarsToRow37( bcAccessToken) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars37( bcAccessToken, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0V37( ) ;
         AfterTrn( ) ;
         VarsToRow37( bcAccessToken) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow37( bcAccessToken) ;
         }
         else
         {
            SdtAccessToken auxBC = new SdtAccessToken(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A196AccessTokenToken);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcAccessToken);
               auxBC.Save();
               bcAccessToken.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars37( bcAccessToken, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars37( bcAccessToken, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0V37( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow37( bcAccessToken) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow37( bcAccessToken) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars37( bcAccessToken, 0) ;
         GetKey0V37( ) ;
         if ( RcdFound37 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A196AccessTokenToken, Z196AccessTokenToken) != 0 )
            {
               A196AccessTokenToken = Z196AccessTokenToken;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(A196AccessTokenToken, Z196AccessTokenToken) != 0 )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         context.RollbackDataStores("accesstoken_bc",pr_default);
         VarsToRow37( bcAccessToken) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcAccessToken.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcAccessToken.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcAccessToken )
         {
            bcAccessToken = (SdtAccessToken)(sdt);
            if ( StringUtil.StrCmp(bcAccessToken.gxTpr_Mode, "") == 0 )
            {
               bcAccessToken.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow37( bcAccessToken) ;
            }
            else
            {
               RowToVars37( bcAccessToken, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcAccessToken.gxTpr_Mode, "") == 0 )
            {
               bcAccessToken.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars37( bcAccessToken, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtAccessToken AccessToken_BC
      {
         get {
            return bcAccessToken ;
         }

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
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected override void createObjects( )
      {
      }

      protected void Process( )
      {
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
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z196AccessTokenToken = "";
         A196AccessTokenToken = "";
         Z260AccessTokenDate = (DateTime)(DateTime.MinValue);
         A260AccessTokenDate = (DateTime)(DateTime.MinValue);
         BC000V4_A196AccessTokenToken = new string[] {""} ;
         BC000V4_A261AccessTokenDuration = new int[1] ;
         BC000V4_A260AccessTokenDate = new DateTime[] {DateTime.MinValue} ;
         BC000V5_A196AccessTokenToken = new string[] {""} ;
         BC000V3_A196AccessTokenToken = new string[] {""} ;
         BC000V3_A261AccessTokenDuration = new int[1] ;
         BC000V3_A260AccessTokenDate = new DateTime[] {DateTime.MinValue} ;
         sMode37 = "";
         BC000V2_A196AccessTokenToken = new string[] {""} ;
         BC000V2_A261AccessTokenDuration = new int[1] ;
         BC000V2_A260AccessTokenDate = new DateTime[] {DateTime.MinValue} ;
         BC000V9_A196AccessTokenToken = new string[] {""} ;
         BC000V9_A261AccessTokenDuration = new int[1] ;
         BC000V9_A260AccessTokenDate = new DateTime[] {DateTime.MinValue} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.accesstoken_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.accesstoken_bc__default(),
            new Object[][] {
                new Object[] {
               BC000V2_A196AccessTokenToken, BC000V2_A261AccessTokenDuration, BC000V2_A260AccessTokenDate
               }
               , new Object[] {
               BC000V3_A196AccessTokenToken, BC000V3_A261AccessTokenDuration, BC000V3_A260AccessTokenDate
               }
               , new Object[] {
               BC000V4_A196AccessTokenToken, BC000V4_A261AccessTokenDuration, BC000V4_A260AccessTokenDate
               }
               , new Object[] {
               BC000V5_A196AccessTokenToken
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000V9_A196AccessTokenToken, BC000V9_A261AccessTokenDuration, BC000V9_A260AccessTokenDate
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z262AccessTokenValid ;
      private short A262AccessTokenValid ;
      private short RcdFound37 ;
      private int trnEnded ;
      private int Z261AccessTokenDuration ;
      private int A261AccessTokenDuration ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode37 ;
      private DateTime Z260AccessTokenDate ;
      private DateTime A260AccessTokenDate ;
      private string Z196AccessTokenToken ;
      private string A196AccessTokenToken ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000V4_A196AccessTokenToken ;
      private int[] BC000V4_A261AccessTokenDuration ;
      private DateTime[] BC000V4_A260AccessTokenDate ;
      private string[] BC000V5_A196AccessTokenToken ;
      private string[] BC000V3_A196AccessTokenToken ;
      private int[] BC000V3_A261AccessTokenDuration ;
      private DateTime[] BC000V3_A260AccessTokenDate ;
      private string[] BC000V2_A196AccessTokenToken ;
      private int[] BC000V2_A261AccessTokenDuration ;
      private DateTime[] BC000V2_A260AccessTokenDate ;
      private string[] BC000V9_A196AccessTokenToken ;
      private int[] BC000V9_A261AccessTokenDuration ;
      private DateTime[] BC000V9_A260AccessTokenDate ;
      private SdtAccessToken bcAccessToken ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class accesstoken_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class accesstoken_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000V2;
        prmBC000V2 = new Object[] {
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0)
        };
        Object[] prmBC000V3;
        prmBC000V3 = new Object[] {
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0)
        };
        Object[] prmBC000V4;
        prmBC000V4 = new Object[] {
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0)
        };
        Object[] prmBC000V5;
        prmBC000V5 = new Object[] {
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0)
        };
        Object[] prmBC000V6;
        prmBC000V6 = new Object[] {
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0) ,
        new ParDef("@AccessTokenDuration",GXType.Int32,8,0) ,
        new ParDef("@AccessTokenDate",GXType.DateTime,8,5)
        };
        Object[] prmBC000V7;
        prmBC000V7 = new Object[] {
        new ParDef("@AccessTokenDuration",GXType.Int32,8,0) ,
        new ParDef("@AccessTokenDate",GXType.DateTime,8,5) ,
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0)
        };
        Object[] prmBC000V8;
        prmBC000V8 = new Object[] {
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0)
        };
        Object[] prmBC000V9;
        prmBC000V9 = new Object[] {
        new ParDef("@AccessTokenToken",GXType.NVarChar,150,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000V2", "SELECT [AccessTokenToken], [AccessTokenDuration], [AccessTokenDate] FROM [AccessToken] WITH (UPDLOCK) WHERE [AccessTokenToken] = @AccessTokenToken ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000V2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000V3", "SELECT [AccessTokenToken], [AccessTokenDuration], [AccessTokenDate] FROM [AccessToken] WHERE [AccessTokenToken] = @AccessTokenToken ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000V3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000V4", "SELECT TM1.[AccessTokenToken], TM1.[AccessTokenDuration], TM1.[AccessTokenDate] FROM [AccessToken] TM1 WHERE TM1.[AccessTokenToken] = @AccessTokenToken ORDER BY TM1.[AccessTokenToken]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000V4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000V5", "SELECT [AccessTokenToken] FROM [AccessToken] WHERE [AccessTokenToken] = @AccessTokenToken  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000V5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000V6", "INSERT INTO [AccessToken]([AccessTokenToken], [AccessTokenDuration], [AccessTokenDate]) VALUES(@AccessTokenToken, @AccessTokenDuration, @AccessTokenDate)", GxErrorMask.GX_NOMASK,prmBC000V6)
           ,new CursorDef("BC000V7", "UPDATE [AccessToken] SET [AccessTokenDuration]=@AccessTokenDuration, [AccessTokenDate]=@AccessTokenDate  WHERE [AccessTokenToken] = @AccessTokenToken", GxErrorMask.GX_NOMASK,prmBC000V7)
           ,new CursorDef("BC000V8", "DELETE FROM [AccessToken]  WHERE [AccessTokenToken] = @AccessTokenToken", GxErrorMask.GX_NOMASK,prmBC000V8)
           ,new CursorDef("BC000V9", "SELECT TM1.[AccessTokenToken], TM1.[AccessTokenDuration], TM1.[AccessTokenDate] FROM [AccessToken] TM1 WHERE TM1.[AccessTokenToken] = @AccessTokenToken ORDER BY TM1.[AccessTokenToken]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000V9,100, GxCacheFrequency.OFF ,true,false )
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
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              return;
     }
  }

}

}

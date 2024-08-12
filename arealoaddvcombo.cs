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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class arealoaddvcombo : GXProcedure
   {
      public arealoaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public arealoaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           long aP2_AreaId ,
                           out string aP3_SelectedValue ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15AreaId = aP2_AreaId;
         this.AV16SelectedValue = "" ;
         this.AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         initialize();
         ExecutePrivate();
         aP3_SelectedValue=this.AV16SelectedValue;
         aP4_Combo_Data=this.AV11Combo_Data;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> executeUdp( string aP0_ComboName ,
                                                                                                    string aP1_TrnMode ,
                                                                                                    long aP2_AreaId ,
                                                                                                    out string aP3_SelectedValue )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_AreaId, out aP3_SelectedValue, out aP4_Combo_Data);
         return AV11Combo_Data ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 long aP2_AreaId ,
                                 out string aP3_SelectedValue ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data )
      {
         this.AV13ComboName = aP0_ComboName;
         this.AV14TrnMode = aP1_TrnMode;
         this.AV15AreaId = aP2_AreaId;
         this.AV16SelectedValue = "" ;
         this.AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "") ;
         SubmitImpl();
         aP3_SelectedValue=this.AV16SelectedValue;
         aP4_Combo_Data=this.AV11Combo_Data;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21SDTContexto.FromJSonString(AV20WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
         AV19EmpresaId = AV21SDTContexto.gxTpr_Empresaid;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         if ( StringUtil.StrCmp(AV13ComboName, "UsuarioId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_USUARIOID' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_USUARIOID' Routine */
         returnInSub = false;
         /* Using cursor P00GU2 */
         pr_default.execute(0, new Object[] {AV19EmpresaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A14UsuarioAtivo = P00GU2_A14UsuarioAtivo[0];
            A7UsuarioEmpresaId = P00GU2_A7UsuarioEmpresaId[0];
            n7UsuarioEmpresaId = P00GU2_n7UsuarioEmpresaId[0];
            A9UsuarioId = P00GU2_A9UsuarioId[0];
            A10UsuarioNome = P00GU2_A10UsuarioNome[0];
            AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
            AV12Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A9UsuarioId), 18, 0));
            AV12Combo_DataItem.gxTpr_Title = A10UsuarioNome;
            AV11Combo_Data.Add(AV12Combo_DataItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV16SelectedValue = "";
         AV11Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV21SDTContexto = new SdtSDTContexto(context);
         AV20WebSession = context.GetSession();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00GU2_A14UsuarioAtivo = new bool[] {false} ;
         P00GU2_A7UsuarioEmpresaId = new long[1] ;
         P00GU2_n7UsuarioEmpresaId = new bool[] {false} ;
         P00GU2_A9UsuarioId = new long[1] ;
         P00GU2_A10UsuarioNome = new string[] {""} ;
         A10UsuarioNome = "";
         AV12Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.arealoaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P00GU2_A14UsuarioAtivo, P00GU2_A7UsuarioEmpresaId, P00GU2_n7UsuarioEmpresaId, P00GU2_A9UsuarioId, P00GU2_A10UsuarioNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV15AreaId ;
      private long AV19EmpresaId ;
      private long A7UsuarioEmpresaId ;
      private long A9UsuarioId ;
      private string AV14TrnMode ;
      private string A10UsuarioNome ;
      private bool returnInSub ;
      private bool A14UsuarioAtivo ;
      private bool n7UsuarioEmpresaId ;
      private string AV13ComboName ;
      private string AV16SelectedValue ;
      private IGxSession AV20WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV11Combo_Data ;
      private SdtSDTContexto AV21SDTContexto ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private IDataStoreProvider pr_default ;
      private bool[] P00GU2_A14UsuarioAtivo ;
      private long[] P00GU2_A7UsuarioEmpresaId ;
      private bool[] P00GU2_n7UsuarioEmpresaId ;
      private long[] P00GU2_A9UsuarioId ;
      private string[] P00GU2_A10UsuarioNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV12Combo_DataItem ;
      private string aP3_SelectedValue ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> aP4_Combo_Data ;
   }

   public class arealoaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00GU2;
          prmP00GU2 = new Object[] {
          new ParDef("@AV19EmpresaId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GU2", "SELECT [UsuarioAtivo], [UsuarioEmpresaId], [UsuarioId], [UsuarioNome] FROM [Usuario] WHERE ([UsuarioAtivo] = 1) AND ([UsuarioEmpresaId] = @AV19EmpresaId) ORDER BY [UsuarioNome] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GU2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 60);
                return;
       }
    }

 }

}

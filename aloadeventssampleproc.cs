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
   public class aloadeventssampleproc : GXProcedure
   {
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

      public aloadeventssampleproc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme", false);
      }

      public aloadeventssampleproc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_dateFrom ,
                           DateTime aP1_dateTo ,
                           out SdtSchedulerEvents aP2_events )
      {
         this.AV10dateFrom = aP0_dateFrom;
         this.AV11dateTo = aP1_dateTo;
         this.AV9events = new SdtSchedulerEvents(context) ;
         initialize();
         ExecutePrivate();
         aP2_events=this.AV9events;
      }

      public SdtSchedulerEvents executeUdp( DateTime aP0_dateFrom ,
                                            DateTime aP1_dateTo )
      {
         execute(aP0_dateFrom, aP1_dateTo, out aP2_events);
         return AV9events ;
      }

      public void executeSubmit( DateTime aP0_dateFrom ,
                                 DateTime aP1_dateTo ,
                                 out SdtSchedulerEvents aP2_events )
      {
         this.AV10dateFrom = aP0_dateFrom;
         this.AV11dateTo = aP1_dateTo;
         this.AV9events = new SdtSchedulerEvents(context) ;
         SubmitImpl();
         aP2_events=this.AV9events;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV17SDTContexto.FromJSonString(AV16WebSession.Get(context.GetMessage( "SDTContexto", "")), null);
         AV30PerfilUsuario = AV17SDTContexto.gxTpr_Usuarioperfil;
         AV31UsuarioId = AV17SDTContexto.gxTpr_Usuarioid;
         AV15EmpresaId = AV17SDTContexto.gxTpr_Empresaid;
         AV13ClienteIdVarChar = AV16WebSession.Get(context.GetMessage( "Cliente", ""));
         AV14ClienteId = (long)(Math.Round(NumberUtil.Val( AV13ClienteIdVarChar, "."), 18, MidpointRounding.ToEven));
         AV18GestaoServicoIdVarChar = AV16WebSession.Get(context.GetMessage( "GestaoServico", ""));
         AV19GestaoServicoId = (long)(Math.Round(NumberUtil.Val( AV18GestaoServicoIdVarChar, "."), 18, MidpointRounding.ToEven));
         AV20ExecutanteIdVarChar = AV16WebSession.Get(context.GetMessage( "Executante", ""));
         AV21ExecutanteId = (long)(Math.Round(NumberUtil.Val( AV20ExecutanteIdVarChar, "."), 18, MidpointRounding.ToEven));
         if ( AV30PerfilUsuario == 4 )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV14ClienteId ,
                                                 AV19GestaoServicoId ,
                                                 A440ProgramadaClienteId ,
                                                 A438ProgramadaDemandaId ,
                                                 A439ProgramadaEmpresaId ,
                                                 AV15EmpresaId ,
                                                 AV31UsuarioId ,
                                                 A436TecnicoId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                                 }
            });
            /* Using cursor P00AQ2 */
            pr_default.execute(0, new Object[] {AV31UsuarioId, AV15EmpresaId, AV14ClienteId, AV19GestaoServicoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A436TecnicoId = P00AQ2_A436TecnicoId[0];
               n436TecnicoId = P00AQ2_n436TecnicoId[0];
               A438ProgramadaDemandaId = P00AQ2_A438ProgramadaDemandaId[0];
               A440ProgramadaClienteId = P00AQ2_A440ProgramadaClienteId[0];
               A439ProgramadaEmpresaId = P00AQ2_A439ProgramadaEmpresaId[0];
               A427GestaoServicoProgramadaId = P00AQ2_A427GestaoServicoProgramadaId[0];
               A442ProgramadaDescricao = P00AQ2_A442ProgramadaDescricao[0];
               A441ProgramadaNumero = P00AQ2_A441ProgramadaNumero[0];
               A426GestaoServicoNovaDtProgramada = P00AQ2_A426GestaoServicoNovaDtProgramada[0];
               AV8event = new SdtSchedulerEvents_event(context);
               AV8event.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A427GestaoServicoProgramadaId), 18, 0))+"#"+StringUtil.Str( (decimal)(A438ProgramadaDemandaId), 18, 0);
               AV8event.gxTpr_Name = A442ProgramadaDescricao;
               AV8event.gxTpr_Notes = "#"+StringUtil.Trim( StringUtil.Str( (decimal)(A441ProgramadaNumero), 4, 0))+" - "+StringUtil.Trim( A442ProgramadaDescricao);
               GXt_dtime1 = DateTimeUtil.ResetTime( A426GestaoServicoNovaDtProgramada ) ;
               AV8event.gxTpr_Starttime = GXt_dtime1;
               GXt_dtime1 = DateTimeUtil.ResetTime( A426GestaoServicoNovaDtProgramada ) ;
               AV8event.gxTpr_Endtime = GXt_dtime1;
               AV8event.gxTpr_Additionalinformation = "";
               AV33GXV1 = 1;
               while ( AV33GXV1 <= AV23DateCollection.Count )
               {
                  AV25Date = AV23DateCollection.GetDatetime(AV33GXV1);
                  if ( DateTimeUtil.ResetTime ( AV25Date ) == DateTimeUtil.ResetTime ( A426GestaoServicoNovaDtProgramada ) )
                  {
                     AV29IsDateExiste = true;
                  }
                  else
                  {
                     AV29IsDateExiste = false;
                  }
                  AV33GXV1 = (int)(AV33GXV1+1);
               }
               if ( ! AV29IsDateExiste )
               {
                  AV9events.gxTpr_Items.Add(AV8event, 0);
                  AV23DateCollection.Add(A426GestaoServicoNovaDtProgramada, 0);
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV14ClienteId ,
                                                 AV19GestaoServicoId ,
                                                 AV21ExecutanteId ,
                                                 A440ProgramadaClienteId ,
                                                 A438ProgramadaDemandaId ,
                                                 A436TecnicoId ,
                                                 A439ProgramadaEmpresaId ,
                                                 AV15EmpresaId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor P00AQ3 */
            pr_default.execute(1, new Object[] {AV15EmpresaId, AV14ClienteId, AV19GestaoServicoId, AV21ExecutanteId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A436TecnicoId = P00AQ3_A436TecnicoId[0];
               n436TecnicoId = P00AQ3_n436TecnicoId[0];
               A438ProgramadaDemandaId = P00AQ3_A438ProgramadaDemandaId[0];
               A440ProgramadaClienteId = P00AQ3_A440ProgramadaClienteId[0];
               A439ProgramadaEmpresaId = P00AQ3_A439ProgramadaEmpresaId[0];
               A427GestaoServicoProgramadaId = P00AQ3_A427GestaoServicoProgramadaId[0];
               A442ProgramadaDescricao = P00AQ3_A442ProgramadaDescricao[0];
               A441ProgramadaNumero = P00AQ3_A441ProgramadaNumero[0];
               A426GestaoServicoNovaDtProgramada = P00AQ3_A426GestaoServicoNovaDtProgramada[0];
               AV8event = new SdtSchedulerEvents_event(context);
               AV8event.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A427GestaoServicoProgramadaId), 18, 0))+"#"+StringUtil.Str( (decimal)(A438ProgramadaDemandaId), 18, 0);
               AV8event.gxTpr_Name = A442ProgramadaDescricao;
               AV8event.gxTpr_Notes = "#"+StringUtil.Trim( StringUtil.Str( (decimal)(A441ProgramadaNumero), 4, 0))+" - "+StringUtil.Trim( A442ProgramadaDescricao);
               GXt_dtime1 = DateTimeUtil.ResetTime( A426GestaoServicoNovaDtProgramada ) ;
               AV8event.gxTpr_Starttime = GXt_dtime1;
               GXt_dtime1 = DateTimeUtil.ResetTime( A426GestaoServicoNovaDtProgramada ) ;
               AV8event.gxTpr_Endtime = GXt_dtime1;
               AV8event.gxTpr_Additionalinformation = "";
               AV35GXV2 = 1;
               while ( AV35GXV2 <= AV23DateCollection.Count )
               {
                  AV25Date = AV23DateCollection.GetDatetime(AV35GXV2);
                  if ( DateTimeUtil.ResetTime ( AV25Date ) == DateTimeUtil.ResetTime ( A426GestaoServicoNovaDtProgramada ) )
                  {
                     AV29IsDateExiste = true;
                  }
                  else
                  {
                     AV29IsDateExiste = false;
                  }
                  AV35GXV2 = (int)(AV35GXV2+1);
               }
               if ( ! AV29IsDateExiste )
               {
                  AV9events.gxTpr_Items.Add(AV8event, 0);
                  AV23DateCollection.Add(A426GestaoServicoNovaDtProgramada, 0);
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         this.cleanup();
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
         AV9events = new SdtSchedulerEvents(context);
         AV17SDTContexto = new SdtSDTContexto(context);
         AV16WebSession = context.GetSession();
         AV13ClienteIdVarChar = "";
         AV18GestaoServicoIdVarChar = "";
         AV20ExecutanteIdVarChar = "";
         P00AQ2_A436TecnicoId = new long[1] ;
         P00AQ2_n436TecnicoId = new bool[] {false} ;
         P00AQ2_A438ProgramadaDemandaId = new long[1] ;
         P00AQ2_A440ProgramadaClienteId = new long[1] ;
         P00AQ2_A439ProgramadaEmpresaId = new long[1] ;
         P00AQ2_A427GestaoServicoProgramadaId = new long[1] ;
         P00AQ2_A442ProgramadaDescricao = new string[] {""} ;
         P00AQ2_A441ProgramadaNumero = new short[1] ;
         P00AQ2_A426GestaoServicoNovaDtProgramada = new DateTime[] {DateTime.MinValue} ;
         A442ProgramadaDescricao = "";
         A426GestaoServicoNovaDtProgramada = DateTime.MinValue;
         AV8event = new SdtSchedulerEvents_event(context);
         AV23DateCollection = new GxSimpleCollection<DateTime>();
         AV25Date = DateTime.MinValue;
         P00AQ3_A436TecnicoId = new long[1] ;
         P00AQ3_n436TecnicoId = new bool[] {false} ;
         P00AQ3_A438ProgramadaDemandaId = new long[1] ;
         P00AQ3_A440ProgramadaClienteId = new long[1] ;
         P00AQ3_A439ProgramadaEmpresaId = new long[1] ;
         P00AQ3_A427GestaoServicoProgramadaId = new long[1] ;
         P00AQ3_A442ProgramadaDescricao = new string[] {""} ;
         P00AQ3_A441ProgramadaNumero = new short[1] ;
         P00AQ3_A426GestaoServicoNovaDtProgramada = new DateTime[] {DateTime.MinValue} ;
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aloadeventssampleproc__default(),
            new Object[][] {
                new Object[] {
               P00AQ2_A436TecnicoId, P00AQ2_n436TecnicoId, P00AQ2_A438ProgramadaDemandaId, P00AQ2_A440ProgramadaClienteId, P00AQ2_A439ProgramadaEmpresaId, P00AQ2_A427GestaoServicoProgramadaId, P00AQ2_A442ProgramadaDescricao, P00AQ2_A441ProgramadaNumero, P00AQ2_A426GestaoServicoNovaDtProgramada
               }
               , new Object[] {
               P00AQ3_A436TecnicoId, P00AQ3_n436TecnicoId, P00AQ3_A438ProgramadaDemandaId, P00AQ3_A440ProgramadaClienteId, P00AQ3_A439ProgramadaEmpresaId, P00AQ3_A427GestaoServicoProgramadaId, P00AQ3_A442ProgramadaDescricao, P00AQ3_A441ProgramadaNumero, P00AQ3_A426GestaoServicoNovaDtProgramada
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV30PerfilUsuario ;
      private short A441ProgramadaNumero ;
      private int AV33GXV1 ;
      private int AV35GXV2 ;
      private long AV31UsuarioId ;
      private long AV15EmpresaId ;
      private long AV14ClienteId ;
      private long AV19GestaoServicoId ;
      private long AV21ExecutanteId ;
      private long A440ProgramadaClienteId ;
      private long A438ProgramadaDemandaId ;
      private long A439ProgramadaEmpresaId ;
      private long A436TecnicoId ;
      private long A427GestaoServicoProgramadaId ;
      private DateTime GXt_dtime1 ;
      private DateTime AV10dateFrom ;
      private DateTime AV11dateTo ;
      private DateTime A426GestaoServicoNovaDtProgramada ;
      private DateTime AV25Date ;
      private bool n436TecnicoId ;
      private bool AV29IsDateExiste ;
      private string AV13ClienteIdVarChar ;
      private string AV18GestaoServicoIdVarChar ;
      private string AV20ExecutanteIdVarChar ;
      private string A442ProgramadaDescricao ;
      private IGxSession AV16WebSession ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private SdtSchedulerEvents AV9events ;
      private SdtSDTContexto AV17SDTContexto ;
      private IDataStoreProvider pr_default ;
      private long[] P00AQ2_A436TecnicoId ;
      private bool[] P00AQ2_n436TecnicoId ;
      private long[] P00AQ2_A438ProgramadaDemandaId ;
      private long[] P00AQ2_A440ProgramadaClienteId ;
      private long[] P00AQ2_A439ProgramadaEmpresaId ;
      private long[] P00AQ2_A427GestaoServicoProgramadaId ;
      private string[] P00AQ2_A442ProgramadaDescricao ;
      private short[] P00AQ2_A441ProgramadaNumero ;
      private DateTime[] P00AQ2_A426GestaoServicoNovaDtProgramada ;
      private SdtSchedulerEvents_event AV8event ;
      private GxSimpleCollection<DateTime> AV23DateCollection ;
      private long[] P00AQ3_A436TecnicoId ;
      private bool[] P00AQ3_n436TecnicoId ;
      private long[] P00AQ3_A438ProgramadaDemandaId ;
      private long[] P00AQ3_A440ProgramadaClienteId ;
      private long[] P00AQ3_A439ProgramadaEmpresaId ;
      private long[] P00AQ3_A427GestaoServicoProgramadaId ;
      private string[] P00AQ3_A442ProgramadaDescricao ;
      private short[] P00AQ3_A441ProgramadaNumero ;
      private DateTime[] P00AQ3_A426GestaoServicoNovaDtProgramada ;
      private SdtSchedulerEvents aP2_events ;
   }

   public class aloadeventssampleproc__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AQ2( IGxContext context ,
                                             long AV14ClienteId ,
                                             long AV19GestaoServicoId ,
                                             long A440ProgramadaClienteId ,
                                             long A438ProgramadaDemandaId ,
                                             long A439ProgramadaEmpresaId ,
                                             long AV15EmpresaId ,
                                             long AV31UsuarioId ,
                                             long A436TecnicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[4];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [TecnicoId], [ProgramadaDemandaId], [ProgramadaClienteId], [ProgramadaEmpresaId], [GestaoServicoProgramadaId], [ProgramadaDescricao], [ProgramadaNumero], [GestaoServicoNovaDtProgramada] FROM [GestaoServicoProgramada]";
         AddWhere(sWhereString, "([TecnicoId] = @AV31UsuarioId)");
         AddWhere(sWhereString, "([ProgramadaEmpresaId] = @AV15EmpresaId)");
         if ( ! (0==AV14ClienteId) )
         {
            AddWhere(sWhereString, "([ProgramadaClienteId] = @AV14ClienteId)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV19GestaoServicoId) )
         {
            AddWhere(sWhereString, "([ProgramadaDemandaId] = @AV19GestaoServicoId)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TecnicoId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00AQ3( IGxContext context ,
                                             long AV14ClienteId ,
                                             long AV19GestaoServicoId ,
                                             long AV21ExecutanteId ,
                                             long A440ProgramadaClienteId ,
                                             long A438ProgramadaDemandaId ,
                                             long A436TecnicoId ,
                                             long A439ProgramadaEmpresaId ,
                                             long AV15EmpresaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[4];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [TecnicoId], [ProgramadaDemandaId], [ProgramadaClienteId], [ProgramadaEmpresaId], [GestaoServicoProgramadaId], [ProgramadaDescricao], [ProgramadaNumero], [GestaoServicoNovaDtProgramada] FROM [GestaoServicoProgramada]";
         AddWhere(sWhereString, "([ProgramadaEmpresaId] = @AV15EmpresaId)");
         if ( ! (0==AV14ClienteId) )
         {
            AddWhere(sWhereString, "([ProgramadaClienteId] = @AV14ClienteId)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ! (0==AV19GestaoServicoId) )
         {
            AddWhere(sWhereString, "([ProgramadaDemandaId] = @AV19GestaoServicoId)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV21ExecutanteId) )
         {
            AddWhere(sWhereString, "([TecnicoId] = @AV21ExecutanteId)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [GestaoServicoProgramadaId]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00AQ2(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] );
               case 1 :
                     return conditional_P00AQ3(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (long)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (long)dynConstraints[7] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AQ2;
          prmP00AQ2 = new Object[] {
          new ParDef("@AV31UsuarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV15EmpresaId",GXType.Decimal,18,0) ,
          new ParDef("@AV14ClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV19GestaoServicoId",GXType.Decimal,18,0)
          };
          Object[] prmP00AQ3;
          prmP00AQ3 = new Object[] {
          new ParDef("@AV15EmpresaId",GXType.Decimal,18,0) ,
          new ParDef("@AV14ClienteId",GXType.Decimal,18,0) ,
          new ParDef("@AV19GestaoServicoId",GXType.Decimal,18,0) ,
          new ParDef("@AV21ExecutanteId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AQ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AQ2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00AQ3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AQ3,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                return;
       }
    }

 }

}

using SqlScriptBuilder.Library;
using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Factories;
using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SqlScript.ConsoleExe;

internal class Program
{
    static void Main( string[] args )
    {
        var script = ExampleTwo();
        var sql = script.ToString();

        Console.WriteLine( sql.ToUpper() );
        Console.ReadLine();
    }

    private static ISqlScript ExampleZero()
    {
        var abstractFactory = new SqlScriptBuilderAbstractFactory();
        var factory = abstractFactory.CreateReadFactory();
        var builder = factory.CreateSqlReadScriptBuilder();

        builder.Select().Field( "getdate()" );

        var script = builder.Build();
        return script;
    }

    private static ISqlScript ExampleOne()
    {
        var abstractFactory = new SqlScriptBuilderAbstractFactory();
        var factory = abstractFactory.CreateReadFactory();
        var builder = factory.CreateSqlReadScriptBuilder();

        builder.Select()
            .Field( "registrationdate" )
            .Field( "name" )
            .From()
            .Table( "ship" )
            .Group()
            .By( "registrationdate" )
            .By( "name" )
            .Order()
            .By( "registrationdate" )
            .By( "name desc" );

        var script = builder.Build();

        return script;
    }

    private static ISqlScript ExampleTwo()
    {
        var abstractFactory = new SqlScriptBuilderAbstractFactory();
        var factory = abstractFactory.CreateReadFactory();
        var builder = factory.CreateSqlReadScriptBuilder();

        builder.Select()
            .Field( "Pessoa", "COD_PESSOA" )
            .Field( "PESSOA", "NOM_PESSOA", "nom_cliente" )
            .Field( "PESSOA_JURIDICA", "NOM_FANTASIA" )
            .Field( SqlFunctionFactory.IsNull( "PESSOA_JURIDICA.CNPJ_PESSOA", "PESSOA_FISICA.CPF_PESSOA", "CNPJ_CPF" ) )
            .Field( "ENDERECO", "CEL_ENDERECO" )
            .Field( "ENDERECO", "TEL_ENDERECO" )
            .Field( "ENDERECO", "EMAIL_ENDERECO" )
            .Field( "ENDERECO", "DES_LOGRADOURO" )
            .Field( "ENDERECO", "DES_BAIRRO" )
            .Field( "CIDADE", "DES_CIDADE" )
            .Field( "ENDERECO", "SIGLA_ESTADO" )
            .From()
            .Table( "PESSOA" )
            .InnerJoin( "CLIENTE", "COD_CLIENTE", "PESSOA", "COD_PESSOA", null, null )
            .InnerJoin( "ENDERECO", "PESSOA", "COD_PESSOA", "AND TIP_ENDERECO = 0" )
            .InnerJoin( "CIDADE", "ENDERECO", "COD_CIDADE" )
            .InnerJoin( "ESTADO", "CIDADE", "COD_ESTADO" )
            .LeftJoin( "PESSOA_JURIDICA", "PESSOA", "COD_PESSOA" )
            .LeftJoin( "PESSOA_FISICA", "PESSOA", "COD_PESSOA" )
            .Where()
            .Condition( "pessoa", "cod_pessoa", ConditionalOperatorBuilderFactory.Equal( 5 ) )
            .GreaterThan( "pessoa", "cod_pessoa", 1 )
            .GreaterOrEqualThan( "pessoa", "cod_pessoa", 2 )
            .Equal( "pessoa", "cod_pessoa", 5 )
            .LessOrEqualThan( "pessoa", "cod_pessoa", 3 )
            .LessThan( "pessoa", "cod_pessoa", 4 )
            .Different( "pessoa", "cod_pessoa", 6 )
            .Like( "pessoa", "NOM_PESSOA", "Antonio%" )
            .NotLike( "pessoa", "NOM_PESSOA", "%Souza" )
            .In( "pessoa", "cod_pessoa", Enumerable.Range( 1, 5 ), ConditionCombinerFactory.Or() )
            .NotIn( "pessoa", "cod_pessoa", Enumerable.Range( 1, 3 ), ConditionCombinerFactory.Or() )
            .Between( "pessoa", "dat_cadastro", new DateTime( 2025, 09, 01 ), new DateTime( 2025, 09, 30 ) );
        //.OrderBy( "PESSOA.NOM_PESSOA" )
        //.Build();

        var script = builder.Build();

        return script;
    }
}


// Exemplo 3
//DECLARE @__pCodOperacao_0 int = 1 ; DECLARE @__pCodMaquina_1 int = 17 ; DECLARE @__pCodFuncionario_4 int = 8459 ; DECLARE @__pNumLote_3 int = 1 ; 
//SELECT
//    [p].[COD_ORDEM_PRODUCAO], 
//	[t0].[COD_PEDIDO], 
//	COALESCE([p2].[SEQ_LOTE], 0 ), 
//	COALESCE([p].[COD_ORDEM_PRODUCAO_ORIGEM], 0 ), 
//	[p].[COD_LOCAL], 
//	CAST(COALESCE ( [p2].[SEQ_LOTE], 1 ) AS bigint ), 
//	[p].[QTD_ORDEM_PRODUCAO], 
//	[p2].[QTD_LOTE], 
	
//	CASE
//        WHEN[p5].[COD_ORDEM_PRODUCAO_BAIXA] IS NOT NULL THEN[p5].[COD_ORDEM_PRODUCAO_BAIXA]
//ELSE 0 
//	END, 
	
//	CASE
//        WHEN[p5].[COD_ORDEM_PRODUCAO_BAIXA] IS NOT NULL THEN[p5].[DAT_INICIO]
//ELSE[p].[DAT_CADASTRO]
//END, 
	
//	CASE
//        WHEN[p5].[COD_ORDEM_PRODUCAO_BAIXA] IS NOT NULL THEN[p5].[HOR_INICIO]
//ELSE '' 
//	END, 
//	[p].[DAT_FECHAMENTO], 
//	[p].[DAT_FIM], 
//	[p0].[COD_PRODUTO], 
//	COALESCE([p0].[IDE_INTERNA], '' ), 
//	COALESCE([u].[DES_UNIDADE], '' ), 
//	COALESCE([p].[COD_ENGENHARIA], 0 ), 
//	COALESCE([p1].[OBS_ENGENHARIA], '' ), 
//	COALESCE((
//                SELECT
//                    TOP ( 1 ) COALESCE([p6].[COD_OPERACAO], 0 )

//                FROM
//                    [PCP_ESTRUTURA_PROCESSO] AS[p6]

//                WHERE
//                    [p6].[COD_ENGENHARIA] = [p].[COD_ENGENHARIA]
//ORDER BY
//                    [p6].[SEQ_OPERACAO] 
//		), 0 ), 
//	(
//        SELECT
//            COALESCE (SUM (COALESCE ( [p9].[QTD_CONFORME], 0.0E0 ) ), 0.0E0 ) 
//		FROM
//            [PCP_ORDEM_PRODUCAO_BAIXA] AS[p9]

//        WHERE
//            [p9].[COD_ORDEM_PRODUCAO] = [p].[COD_ORDEM_PRODUCAO]
//AND(
//                [p9].[SEQ_LOTE] = [p2].[SEQ_LOTE]

//                 OR (

//                    [p9].[SEQ_LOTE] IS NULL

//                    AND[p2].[SEQ_LOTE] IS NULL
//                )
//		    ) 
//		  	AND[p9].[COD_OPERACAO] = @__pCodOperacao_0 
//	), 
//	COALESCE([t].[COD_OPERACAO], 0 ), 
//	(
//        SELECT
//            COALESCE (SUM (COALESCE ( [p10].[QTD_CONFORME], 0.0E0 ) ), 0.0E0 ) 
//		FROM
//            [PCP_ORDEM_PRODUCAO_BAIXA] AS[p10]

//        WHERE
//            [p10].[COD_ORDEM_PRODUCAO] = [p].[COD_ORDEM_PRODUCAO]
//AND(
//                [p10].[SEQ_LOTE] = [p2].[SEQ_LOTE]

//                 OR (

//                    [p10].[SEQ_LOTE] IS NULL

//                    AND[p2].[SEQ_LOTE] IS NULL
//                )
//		    ) 
//		  	AND(
//                [p10].[COD_OPERACAO] = [t].[COD_OPERACAO]

//                 OR (

//                    [p10].[COD_OPERACAO] IS NULL

//                    AND[t].[COD_OPERACAO] IS NULL
//                )
//		    ) 
//	), 
//	[u].[COD_UNIDADE], 
//	[p1].[COD_ENGENHARIA], 
//	[p2].[COD_ORDEM_PRODUCAO_LOTE], 
//	[t].[COD_ESTRUTURA_PROCESSO], 
//	[p5].[COD_ORDEM_PRODUCAO_BAIXA], 
//	[t0].[COD_ORDEM_PRODUCAO], 
//	[t1].[COD_ORDEM_PRODUCAO_BAIXA], 
//	[t1].[COD_ORDEM_PRODUCAO_BAIXA_COLABORADOR], 
//	[t3].[COD_ESTRUTURA_PROCESSO], 
//	[t3].[COD_ENGENHARIA], 
//	[t3].[COD_ORDEM_PRODUCAO], 
//	[t5].[Codigo], 
//	[t5].[CodEngenharia], 
//	[t5].[CodEstoque], 
//	[t5].[CodProduto], 
//	[t5].[DesProduto], 
//	[t5].[CodSucata], 
//	[t5].[CodEstoqueSucata], 
//	[t5].[ValIndiceConversao], 
//	[t5].[COD_PRODUTO], 
//	COALESCE((
//                SELECT
//                    TOP ( 1 ) COALESCE([p19].[QTD_CONFORME], 0.0E0 )

//                FROM
//                    [PCP_ESTRUTURA_PROCESSO] AS[p17]

//                    CROSS JOIN[PCP_ESTRUTURA_PROCESSO] AS[p18]
//                    CROSS JOIN[PCP_ORDEM_PRODUCAO_BAIXA] AS[p19]

//                WHERE
//                    [p17].[COD_ENGENHARIA] = [p1].[COD_ENGENHARIA]
//AND[p17].[COD_OPERACAO] = @__pCodOperacao_0
//AND[p1].[COD_ENGENHARIA] = [p18].[COD_ENGENHARIA]
//AND[p18].[SEQ_OPERACAO] = [p17].[SEQ_OPERACAO] - 1 
//				  	AND[p19].[COD_ORDEM_PRODUCAO] = [p].[COD_ORDEM_PRODUCAO]
//AND[p19].[COD_OPERACAO] = COALESCE([p18].[COD_OPERACAO], 0 )
//		), 0.0E0 ), 
//	[t1].[DAT_INICIO], 
//	[t1].[c], 
//	[t1].[c0], 
//	[t3].[c], 
//	[t3].[c0]
//FROM
//    [PCP_ORDEM_PRODUCAO] AS[p]

//    INNER JOIN[PRODUTO] AS[p0] ON[p].[COD_PRODUTO] = [p0].[COD_PRODUTO]
//INNER JOIN[UNIDADE_MEDIDA] AS[u] ON[p0].[COD_UNIDADE] = [u].[COD_UNIDADE]
//INNER JOIN[PCP_ENGENHARIA_PRODUTO] AS[p1] ON[p].[COD_ENGENHARIA] = [p1].[COD_ENGENHARIA]
//INNER JOIN[PCP_ORDEM_PRODUCAO_LOTE] AS[p2] ON[p].[COD_ORDEM_PRODUCAO] = [p2].[COD_ORDEM_PRODUCAO]
//OUTER APPLY(
//    SELECT
//        [p3].[COD_OPERACAO],
//        [p3].[COD_ESTRUTURA_PROCESSO]
//        FROM
//            [PCP_ESTRUTURA_PROCESSO] AS [p3]
//        WHERE
//            [p3].[COD_ENGENHARIA] = [p].[COD_ENGENHARIA]

//          AND (

//            [p3].[COD_OPERACAO] = (
//                SELECT

//                    TOP ( 1 ) [p4].[COD_OPERACAO_DEPENDENTE]
//FROM
//                    [PCP_ESTRUTURA_PROCESSO] AS[p4]

//                    WHERE
//                        [p4].[COD_ENGENHARIA] = [p].[COD_ENGENHARIA]
//AND[p4].[COD_OPERACAO] = @__pCodOperacao_0 
//			      ) 
//			 	OR(
//                    [p3].[COD_OPERACAO] IS NULL

//                    AND (

//                    SELECT
//                        TOP ( 1 ) [p4].[COD_OPERACAO_DEPENDENTE]
//FROM
//                        [PCP_ESTRUTURA_PROCESSO] AS[p4]

//                    WHERE
//                        [p4].[COD_ENGENHARIA] = [p].[COD_ENGENHARIA]
//AND[p4].[COD_OPERACAO] = @__pCodOperacao_0 
//				    ) IS NULL
//			    ) 
//		    ) 
//	) AS[t]
//    LEFT JOIN[PCP_ORDEM_PRODUCAO_BAIXA] AS[p5] ON[p].[COD_ORDEM_PRODUCAO] = [p5].[COD_ORDEM_PRODUCAO]
//AND @__pCodMaquina_1 = [p5].[COD_MAQUINA]

//              AND @__pCodOperacao_0 = [p5].[COD_OPERACAO]

//    LEFT JOIN(
//        SELECT
//            [f].[COD_PEDIDO],
//            [f1].[COD_ORDEM_PRODUCAO]
//        FROM
//            [FAT_PEDIDO] AS [f]
//            INNER JOIN [FAT_PEDIDO_PRODUTO] AS[f0] ON [f].[COD_PEDIDO] = [f0].[COD_PEDIDO_PRODUTO]

//            INNER JOIN [FAT_PEDIDO_PRODUTO_RESERVA] AS[f1] ON [f0].[COD_PEDIDO_PRODUTO] = [f1].[COD_PEDIDO_PRODUTO]

//        WHERE
//            [f1].[COD_ORDEM_PRODUCAO] IS NOT NULL
//        GROUP BY
//            [f].[COD_PEDIDO],
//            [f1].[COD_ORDEM_PRODUCAO]

//    ) AS[t0] ON[p].[COD_ORDEM_PRODUCAO] = [t0].[COD_ORDEM_PRODUCAO]
//LEFT JOIN(
//        SELECT
//            [t2].[DAT_INICIO],
//            [t2].[c],
//            [t2].[c0],
//            [t2].[COD_ORDEM_PRODUCAO_BAIXA],
//            [t2].[COD_ORDEM_PRODUCAO_BAIXA_COLABORADOR],
//            [t2].[COD_ORDEM_PRODUCAO]
//        FROM

//            (
//                SELECT
//                    [p7].[DAT_INICIO],
//                    COALESCE ( [p7].[HOR_INICIO], '' ) AS[c], 
//					1 AS[c0], 
//					[p7].[COD_ORDEM_PRODUCAO_BAIXA], 
//					[p8].[COD_ORDEM_PRODUCAO_BAIXA_COLABORADOR], 
//					[p7].[COD_ORDEM_PRODUCAO], 
//					ROW_NUMBER() OVER(PARTITION BY [p7].[COD_ORDEM_PRODUCAO]
//                        ORDER BY

//                            [p7].[COD_ORDEM_PRODUCAO_BAIXA],
//                            [p8].[COD_ORDEM_PRODUCAO_BAIXA_COLABORADOR]

//                    ) AS[row]
//                FROM
//                    [PCP_ORDEM_PRODUCAO_BAIXA] AS[p7]
//                    INNER JOIN[PCP_ORDEM_PRODUCAO_BAIXA_COLABORADOR] AS[p8] ON[p7].[COD_ORDEM_PRODUCAO_BAIXA] = [p8].[COD_ORDEM_PRODUCAO_BAIXA]
//WHERE
//                    [p7].[COD_OPERACAO] = @__pCodOperacao_0
//                      AND[p7].[DAT_FIM]
//IS NULL

//                      AND[p7].[COD_MAQUINA] = @__pCodMaquina_1
//                      AND[p8].[COD_FUNCIONARIO] = @__pCodFuncionario_4 
//			) AS[t2]
//        WHERE
//            [t2].[row] <= 1 
//	) AS[t1] ON[p].[COD_ORDEM_PRODUCAO] = [t1].[COD_ORDEM_PRODUCAO]
//LEFT JOIN(
//        SELECT
//            [t4].[c],
//            [t4].[c0],
//            [t4].[COD_ESTRUTURA_PROCESSO],
//            [t4].[COD_ENGENHARIA],
//            [t4].[COD_ORDEM_PRODUCAO]
//        FROM

//            (
//                SELECT
//                    COALESCE ((( [p12].[QTD_LOTE_PROCESSO] *[p11].[TMP_PADRAO] ) / 60.0E0 ) *[p13].[QTD_ORDEM_PRODUCAO], 0.0E0 ) AS[c], 
//					1 AS[c0], 
//					[p11].[COD_ESTRUTURA_PROCESSO], 
//					[p12].[COD_ENGENHARIA], 
//					[p13].[COD_ORDEM_PRODUCAO], 
//					ROW_NUMBER() OVER(PARTITION BY [p13].[COD_ORDEM_PRODUCAO]
//                        ORDER BY

//                            [p11].[COD_ESTRUTURA_PROCESSO],
//                            [p12].[COD_ENGENHARIA],
//                            [p13].[COD_ORDEM_PRODUCAO]

//                    ) AS[row]
//                FROM
//                    [PCP_ESTRUTURA_PROCESSO] AS[p11]
//                    INNER JOIN[PCP_ENGENHARIA_PRODUTO] AS[p12] ON[p11].[COD_ENGENHARIA] = [p12].[COD_ENGENHARIA]
//INNER JOIN[PCP_ORDEM_PRODUCAO] AS[p13] ON[p12].[COD_ENGENHARIA] = [p13].[COD_ENGENHARIA]
//WHERE
//[p11].[COD_OPERACAO] = @__pCodOperacao_0 
//			) AS[t4]
//        WHERE
//            [t4].[row] <= 1 
//	) AS[t3] ON[p].[COD_ORDEM_PRODUCAO] = [t3].[COD_ORDEM_PRODUCAO]
//LEFT JOIN(
//        SELECT
//            [p14].[COD_ESTRUTURA_PRODUTO] AS[Codigo],
//            [p14].[COD_ENGENHARIA] AS[CodEngenharia],
//            COALESCE ( [p14].[COD_ESTOQUE_BAIXA], [p15].[COD_ESTOQUE], 0 ) AS[CodEstoque], 
//			[p14].[COD_INSUMO] AS[CodProduto], 
//			COALESCE([p15].[DES_PRODUTO], '' ) AS[DesProduto], 
//			COALESCE([p15].[COD_PRODUTO_SUCATA], 0 ) AS[CodSucata], 
//			COALESCE((
//                        SELECT
//                            TOP ( 1 ) [p16].[COD_ESTOQUE]
//FROM
//                            [PRODUTO] AS[p16]

//                        WHERE
//                            [p16].[COD_PRODUTO] = [p15].[COD_PRODUTO_SUCATA] 
//				), 0 ) AS[CodEstoqueSucata], 
//			COALESCE([p15].[QTD_EQUIVALENTE_SUCATA], 0.0E0 ) AS[ValIndiceConversao], 
//			[p15].[COD_PRODUTO]
//FROM
//            [PCP_ESTRUTURA_PRODUTO] AS[p14]

//            INNER JOIN[PRODUTO] AS[p15] ON[p14].[COD_INSUMO] = [p15].[COD_PRODUTO]
//WHERE
//            [p14].[LGC_GERA_PERDA] = CAST( 1 AS bit)

//              AND[p14].[COD_OPERACAO] = @__pCodOperacao_0 
//	) AS[t5] ON[p].[COD_ENGENHARIA] = [t5].[CodEngenharia]
//WHERE
//    [p].[COD_ORDEM_PRODUCAO] = 9838 
//  	AND[p2].[SEQ_LOTE] = @__pNumLote_3
//      AND[p].[DAT_FECHAMENTO]
//IS NULL

//      AND[p].[COD_LOCAL] IS NOT NULL
//      AND[p].[COD_LOCAL]
//IN( 1, 2 )
//ORDER BY
//    [p].[COD_ORDEM_PRODUCAO], 
//	[p0].[COD_PRODUTO], 
//	[u].[COD_UNIDADE], 
//	[p1].[COD_ENGENHARIA], 
//	[p2].[COD_ORDEM_PRODUCAO_LOTE], 
//	[t].[COD_ESTRUTURA_PROCESSO], 
//	[p5].[COD_ORDEM_PRODUCAO_BAIXA], 
//	[t0].[COD_PEDIDO], 
//	[t0].[COD_ORDEM_PRODUCAO], 
//	[t1].[COD_ORDEM_PRODUCAO_BAIXA], 
//	[t1].[COD_ORDEM_PRODUCAO_BAIXA_COLABORADOR], 
//	[t3].[COD_ESTRUTURA_PROCESSO], 
//	[t3].[COD_ENGENHARIA], 
//	[t3].[COD_ORDEM_PRODUCAO], 
//	[t5].[Codigo]
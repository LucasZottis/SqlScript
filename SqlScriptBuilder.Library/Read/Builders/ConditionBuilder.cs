using SqlScriptBuilder.Library.Interfaces;
using SqlScriptBuilder.Library.Read.Interfaces;
using SqlScriptBuilder.Library.Read.Models;

namespace SqlScriptBuilder.Library.Read.Builders;

internal class ConditionBuilder : IConditionBuilder
{
    private ConditionalOperatorBuilder _conditionBuilder;
    private ConditionCombiner? _combiner;
    private IField? _field;
    private IFunctionBuilder? _functionBuilder;

    public ConditionBuilder( string tableAlias, string fieldName, ConditionalOperatorBuilder operatorBuilder )
    {
        if ( string.IsNullOrWhiteSpace( tableAlias ) )
            throw new ArgumentNullException( nameof( tableAlias ) );
        if ( string.IsNullOrWhiteSpace( fieldName ) )
            throw new ArgumentNullException( nameof( fieldName ) );

        _field = new Field
        {
            TableAlias = tableAlias,
            FieldName = fieldName
        };

        _conditionBuilder = operatorBuilder ?? throw new ArgumentNullException( nameof( operatorBuilder ) );
    }

    public ConditionBuilder( SqlFunctionBuilder sqlFunctionBuilder, ConditionalOperatorBuilder operatorBuilder )
    {
        _functionBuilder = sqlFunctionBuilder ?? throw new ArgumentNullException( nameof( sqlFunctionBuilder ) );
        _conditionBuilder = operatorBuilder ?? throw new ArgumentNullException( nameof( operatorBuilder ) );
    }

    public IConditionBuilder SetCombiner( ConditionCombiner combiner )
    {
        _combiner = combiner ?? throw new ArgumentNullException( nameof( combiner ) );
        return this;
    }

    public IConditionBuilder SetTableAlias( string tableAlias )
    {
        if ( _field == null )
            _field = new Field();

        ( ( Field ) _field ).TableAlias = tableAlias ?? throw new ArgumentNullException( nameof( tableAlias ) );

        return this;
    }

    public IConditionBuilder SetFieldName( string fieldName )
    {
        if ( _field == null )
            _field = new Field();

        ( ( Field ) _field ).FieldName = fieldName ?? throw new ArgumentNullException( nameof( fieldName ) );

        return this;
    }

    public IConditionBuilder SetOperator( ConditionalOperatorBuilder conditionalOperatorBuilder )
    {
        _conditionBuilder = conditionalOperatorBuilder ?? throw new ArgumentNullException( nameof( conditionalOperatorBuilder ) );
        return this;
    }

    public IConditionBuilder SetFunction( IFunctionBuilder functionBuilder )
    {
        _functionBuilder = functionBuilder ?? throw new ArgumentNullException( nameof( functionBuilder ) );
        return this;
    }

    public ISqlScript Build()
    {
        if ( _field == null )
            _field = ( IField ) _functionBuilder.Build();

        return new Condition
        {
            Combiner = _combiner,
            Field = _field,
            Operator = ( ConditionalOperator ) _conditionBuilder.Build()
        };
    }
}
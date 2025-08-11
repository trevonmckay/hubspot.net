namespace HubSpot.NET
{
    public readonly struct SearchFilterOperator
    {
        private readonly string _value;

        public static readonly SearchFilterOperator Eq = new("EQ");

        public static readonly SearchFilterOperator NotEq = new("NEQ");

        public static readonly SearchFilterOperator LT = new("LT");

        public static readonly SearchFilterOperator LTE = new("LTE");

        public static readonly SearchFilterOperator GT = new("GT");

        public static readonly SearchFilterOperator GTE = new("GTE");

        public static readonly SearchFilterOperator Between = new("BETWEEN");

        public static readonly SearchFilterOperator In = new("IN");

        public static readonly SearchFilterOperator NotIn = new("NOT_IN");

        public static readonly SearchFilterOperator HasProperty = new("HAS_PROPERTY");

        public static readonly SearchFilterOperator NotHasProperty = new("NOT_HAS_PROPERTY");

        public static readonly SearchFilterOperator ContainsToken = new("CONTAINS_TOKEN");

        public static readonly SearchFilterOperator NotContainsToken = new("NOT_CONTAINS_TOKEN");

        private SearchFilterOperator(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }

        public static implicit operator string(SearchFilterOperator @operator)
        {
            return @operator._value;
        }
    }
}

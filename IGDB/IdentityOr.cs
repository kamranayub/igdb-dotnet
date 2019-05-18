namespace IGDB {
    public class IdentityOrValue<T> {
        public int? Id {get;private set;}

        public T Value {get;private set;}

        public IdentityOrValue()
        {
        }

        public IdentityOrValue(int id)
        {
            Id = id;
        }

        public IdentityOrValue(T value)
        {
            Value = value;
        }
    }

    public class IdentitiesOrValues<T> {
        public int[] Ids {get;private set;}

        public T[] Values {get;private set;}

        public IdentitiesOrValues()
        {
        }

        public IdentitiesOrValues(int[] ids)
        {
            Ids = ids;
        }

        public IdentitiesOrValues(T[] values)
        {
            Values = values;
        }
    }
}
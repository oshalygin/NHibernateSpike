using FluentNHibernate.Mapping;

namespace Entities.Mapping
{
    public class CustomerMap: ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
        }
    }
}

using DevExpress.Xpo;

namespace Acme.Module.BusinessObjects.acme
{

    public partial class ServiceType
    {
        public ServiceType(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}

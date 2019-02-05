using DevExpress.Xpo;

namespace Acme.Module.BusinessObjects.acme
{

    public partial class ServiceLocation
    {
        public ServiceLocation(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}

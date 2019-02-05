using DevExpress.Xpo;

namespace Acme.Module.BusinessObjects.acme
{
    public partial class AppService
    {
        public AppService(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}

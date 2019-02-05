using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Acme.Module.BusinessObjects.acme
{

    public partial class UserService
    {
        public UserService(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}

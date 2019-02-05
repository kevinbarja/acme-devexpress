using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Acme.Module.BusinessObjects.acme
{

    public partial class BusinessUnit
    {
        public BusinessUnit(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}

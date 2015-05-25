using System;
using System.Collections.Generic;
using System.DirectoryServices.Linq;
using System.DirectoryServices.Linq.Attributes;
using System.DirectoryServices.Linq.EntryObjects;
using System.Linq;
using System.Web;

namespace ADPortal.Models
{
    [DirectoryType("group", "OU=Groups")]
    public class Group : EntryObject
    {
        [DirectoryProperty("samaccountname")]
        public string Name { get; set; }

        [EntryCollectionProperty("memberOf", MatchingRule = MatchingRuleType.InChain)]
        public EntryCollection<User> Users
        {
            get
            {
                return ((IEntryWithRelationships)this).RelationshipManager.GetEntryCollection<User>("Users");
            }
        }
    }

}
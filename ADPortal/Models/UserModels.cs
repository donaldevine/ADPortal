using System;
using System.Collections.Generic;
using System.DirectoryServices.Linq;
using System.DirectoryServices.Linq.Attributes;
using System.DirectoryServices.Linq.EntryObjects;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ADPortal.Models
{
    [DirectoryType("User", "OU=InternalUsers")]
    public class User : UserEntryObject
    {
        private Guid _id;
        private string _email;
        private string _userName;
        private string _firstName;
        private string _lastName;
        private DateTime? _whenChanged;

        [DirectoryProperty("objectguid", true)]
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        [DirectoryProperty("whenchanged", true)]
        public DateTime? LastModifiedDate
        {
            get
            {
                return _whenChanged;
            }
            set
            {
                _whenChanged = value;
            }
        }

        [DirectoryProperty("samaccountname")]
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    NotifyPropertyChanged("UserName");
                }
            }
        }

        [DirectoryProperty("givenName")]
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }

        [DirectoryProperty("sn")]
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }

        [DirectoryProperty("mail")]
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    NotifyPropertyChanged("Email");
                }
            }
        }

        [EntryCollectionProperty("member")]
        public EntryCollection<Group> Groups
        {
            get
            {
                return ((IEntryWithRelationships)this).RelationshipManager.GetEntryCollection<Group>("Groups");
            }
        }
    }

    public class UserContext : DirectoryContext
    {
        public UserContext()
            : base(string.Empty)
        {

        }

        private IEntrySet<User> _users;
        private IEntrySet<Group> _groups;

        public IEntrySet<User> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = CreateEntrySet<User>();
                }

                return _users;
            }
        }

        public IEntrySet<Group> Groups
        {
            get
            {
                if (_groups == null)
                {
                    _groups = CreateEntrySet<Group>();
                }

                return _groups;
            }
        }
    }

}
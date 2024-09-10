namespace HomeMgmt.Utils
{
    public class Constants
    {
    }

    public class GENERAL
    {
        public const int PAGE_SIZE = 10;
    }

    public class AUTHORIZATION
    {
        public const string EXCLUDE_INACTIVE = "ExcludeInactive";
        public const string UNAUTHORIZED_ACCOUNT = "UnauthorizedUserAccount";
    }

    public class NOTIFICATION_TYPE
    {
        public const string DEMO = "Demo";
    }

    public class NOTIFICATION_DETAIL
    {
        public const string DEMO_NOTIFICATION = "Demo Notification";
    }

    public class USER_STATUS
    {
        public const string NEW = "New";
        public const string INACTIVE = "Inactive";
        public const string ACTIVE = "Active";
        public const string BANNED = "Banned";
        public const string DELETED = "Deleted";
    }

    public class SEEDED_ROLES
    {
        public const string SUPER_ADMIN = "Super Admin";
        public const string DEFAULT_ROLE = "Default Role";
    }

    public class CATEGORY_TYPES
    {
        public const string ITEM = "Item";
        public const string BILL = "Bill";
    }
}

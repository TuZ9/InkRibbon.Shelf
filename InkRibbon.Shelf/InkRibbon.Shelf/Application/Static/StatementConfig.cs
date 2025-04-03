using InkRibbon.Shelf.Domain.Entities;

namespace InkRibbon.Shelf.Application.Static
{
    public static class StatementConfig
    {
        public static string InsertUser(User user)
        {
            return "INSERT INTO users " +
                   "(id_user, id_user_steam, id_user_xbox, id_user_play, real_name, gamer_tag, avatar, avatar_medium, avatar_full, email)" +
                   "VALUES " +
                   "(@IdUser, @IdUserSteam, @IdUserXbox, " +
                   "@IdUserPlay, @RealName, @GamerTag, @Avatar, @Avatarmedium, @Avatarfull, @Email);";
        }

        public static string BulkInsertUser(IEnumerable<User> user)
        {
            return "INSERT INTO users " +
                   "(id_user, id_user_steam, id_user_xbox, id_user_play, real_name, gamer_tag, avatar, avatar_medium, avatar_full, email)" +
                   "VALUES " +
                   "(@IdUser, @IdUserSteam, @IdUserXbox, " +
                   "@IdUserPlay, @RealName, @GamerTag, @Avatar, @Avatarmedium, @Avatarfull, @Email);";
        }

        public static string DeleteUser(string idUser)
        {
            return $"DELETE FROM users WHERE id_user = '{idUser}';";
        }

        public static string SelectUser()
        {
            return @"SELECT 
                                id_user AS IdUser, 
                                id_user_steam AS IdUserSteam, 
                                id_user_xbox AS IdUserXbox, 
                                id_user_play AS IdUserPlay, 
                                real_name AS RealName, 
                                gamer_tag AS GamerTag, 
                                avatar AS Avatar, 
                                avatar_medium AS Avatarmedium, 
                                avatar_full AS Avatarfull, 
                                email AS Email
                            FROM users";
        }

        public static string BulkUpdateUser(IEnumerable<User> user)
        {
            return @"UPDATE users
                     SET 
                         id_user_steam = @IdUserSteam,
                         id_user_xbox = @IdUserXbox,
                         id_user_play = @IdUserPlay,
                         real_name = @RealName,
                         gamer_tag = @GamerTag,
                         avatar = @Avatar,
                         avatar_medium = @Avatarmedium,
                         avatar_full = @Avatarfull,
                         email = @Email
                     WHERE id_user = @IdUser;";
        }

        public static string UpdateUser(User user)
        {
            return @"UPDATE users
                     SET 
                         id_user_steam = @IdUserSteam,
                         id_user_xbox = @IdUserXbox,
                         id_user_play = @IdUserPlay,
                         real_name = @RealName,
                         gamer_tag = @GamerTag,
                         avatar = @Avatar,
                         avatar_medium = @Avatarmedium,
                         avatar_full = @Avatarfull,
                         email = @Email
                     WHERE id_user = @IdUser;";
        }
    }
}

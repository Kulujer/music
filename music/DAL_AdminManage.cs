using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace music
{
    public class DAL_AdminManage
    {
        //用户管理
        //获取前一百名用户
        public DataTable GetUsers()
        {
            string sql = "select top 100 * from [user]";
            DataTable dt_temp = sqlHelper.GetDataSet(sql);

            return dt_temp;
        }

        //删除某一个用户
        public bool DeleteUser(int id)
        {
            string DelString = "delete from [user] where [userID]=@userID";
            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@collectID",id),
            };
            int ret = sqlHelper.ExecuteSql(DelString, parameters);
            if (ret == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //编辑用户
        public bool UpdateUser(Model_User user)
        {
            string updateString = "update [dbo].[user] set [password]=@password,[userName]=@userName where [userID]=@userID";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@password",user.Password),
                new SqlParameter("@userName",user.UserName),
                new SqlParameter("@userID",user.ID),
            };
            int ret = sqlHelper.ExecuteSql(updateString, parameters);
            if (ret == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //获取歌曲热度前十
        public DataTable getSongsTop10()
        {
            string sql = "select top 10 * from [t_music] order by [SongName] desc";
            DataTable dt_temp = sqlHelper.GetDataSet(sql);

            return dt_temp;
        }

        //获取歌手热度前十
        public DataTable getSingersTop10()
        {
            string sql = "select top 10 * from [t_singer] order by [SingerName] desc";
            DataTable dt_temp = sqlHelper.GetDataSet(sql);

            return dt_temp;
        }

        //获取所有歌手（前一百）
        public DataTable GetSingers()
        {
            string sql = "select top 100 [ID],[Name],[Hits] from [t_singer] order by [Name]";
            DataTable dt_temp = sqlHelper.GetDataSet(sql);

            return dt_temp;
        }
        //编辑歌手信息
        public bool editSinger(Model_Singer singer)
        {
            string updateString = "update [dbo].[t_singer] set [Name]=@Name,[Hits]=@Hits where [ID]=@ID";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@Name",singer.SingerName),
                new SqlParameter("@Hits",singer.Hits),
                new SqlParameter("@ID",singer.ID),
            };
            int ret = sqlHelper.ExecuteSql(updateString, parameters);
            if (ret == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //获取所有歌曲（前一百）
        public DataTable GetSongs()
        {
            string sql = "select top 100 [SongName],[SingerName],[ID],[TypeName],[Hits] from [t_music] order by [SongName]";
            DataTable dt_temp = sqlHelper.GetDataSet(sql);

            return dt_temp;
        }
        //编辑歌曲信息
        public bool editSong(Model_Song song)
        {
            string updateString = "update [dbo].[t_music] set [SongName]=@SongName,[SingerName]=@SingerName,[TypeName]=@TypeName,[Hits]=@Hits where [ID]=@ID";
            SqlParameter[] parameters = new SqlParameter[] { 
                new SqlParameter("@SongName",song.SongName),
                new SqlParameter("@SingerName",song.SingerName),
                new SqlParameter("@TypeName",song.TypeName),
                new SqlParameter("@Hits",song.Hits),
                new SqlParameter("@ID",song.ID),
            };
            int ret = sqlHelper.ExecuteSql(updateString, parameters);
            if (ret == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
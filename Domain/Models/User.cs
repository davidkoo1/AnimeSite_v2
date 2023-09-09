using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class User : IdentityUser
    {
        //StatusOnline, List<LastPages>, Еще вот призадумался, нужно сделать запоминать "вход" или нет при входе
        //И вот как я придумал сохраниение списка вишлиста к примеру, 
        /*
            пользователь входит, добавляет несколько любимых аниме в список, при выходе мы сериализуем список и сохраняем в бд
            ИдПользователя СостояниеСписка
         */
        public string? ProfileImage { get; set; }
        public virtual IList<Rating>? Rating { get; set; }
        public virtual IList<Comment>? Comment { get; set; }
        public virtual List<FavouriteAnime>? FavouriteAnime { get; set; }
    }
}

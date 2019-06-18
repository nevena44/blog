using Blog.Domen;
using Blog.EfDataAccess;
using System;

namespace Blog.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new BlogContext();

            context.Roles.Add(new Role
            {
                Name = "Admin"
            });

            context.Roles.Add(new Role
            {
                Name = "Korisnik"
            });

            context.Users.Add(new User
            {
                FirstName = "Nevena",
                LastName = "Pejcic",
                Username = "nevena4",
                Password = "nevena4",
                Email = "nevena.pejcic.159.15@ict.edu.rs",
                RoleId = 1
            });

            context.Users.Add(new User
            {
                FirstName = "Nikola",
                LastName = "Kostic",
                Username = "nikola4",
                Password = "nikola4",
                Email = "nikolaa.kosiic@gmail.com",
                RoleId = 2
            });

            context.Hashtags.Add(new Hashtag
            {
                Name = "#BEAUTY"
            });

            context.Hashtags.Add(new Hashtag
            {
                Name = "#LIFE"
            });

            context.Hashtags.Add(new Hashtag
            {
                Name = "#HEAAR"
            });

            context.Hashtags.Add(new Hashtag
            {
                Name = "#PINK"
            });

            context.Hashtags.Add(new Hashtag
            {
                Name = "#DRESS"
            });

            context.Pictures.Add(new Picture {
                Src = "pink1.jpg",
                Alt = "pinkdress"
            });

            context.Pictures.Add(new Picture
            {
                Src = "hairVelika.jpg",
                Alt = "hair"
            });

            context.Pictures.Add(new Picture
            {
                Src = "best.jpg",
                Alt = "bff"
            });

            context.Posts.Add(new Post
            {
                Title = "Outrageous Pink Dresses Ruled The Oscars Red Carpe...",
                SubTitle = "Kacey Musgraves, Gemma Chan, Angela Basset and more rocked the look.",
                Description = "It seems that everyone got the ruffled pink dress memo for the Oscars red carpet on Sunday night. Kacey Musgraves,Gemma Chan, Linda Cardellini, Angela Bassett, Sarah Paulson, Helen Mirren and Maya Rudolph wore some of the most over - the - top looks of the night,wowing in wild ruffles, tulle galore and bright pink realness.Musgraves wowed in Giambattista Valli and told E! that she needed extra room just to walk in her dress.“It’s an honor to be able to get to wear this dress,” the singer said,joking that “it’s like make way for the dress. I need about 10 feet!”Chan looked stunning in a Valentino Haute Couture gown, while Bassett chose a hot - pink, ruffled Reem Acra number that her stylist loved. “She’s somebody that can pull off drama,” Bassett’s stylist, Jennifer Austin, told The Hollywood Reporter. “I loved the drama on the sleeve.”ustin added, “Everybody knows Angela has amazing arms and she loves her arms, so anything that showcases that and heightens that.”Just look at these gorgeous gowns: ",
                UserId = 1,
                PictureId = 1,
                PostHashtags = { 1, 2 , 4 ,5}
            });

            context.Posts.Add(new Post
            {
                Title = "13 Gifts For Your Supportive BFFs Who Should Be Celebrated Every Damn Day",
                SubTitle = "Because every month is Women's History Month if you try hard enough ♀",
                Description = "Women already know we’re magic, we’re just waiting on the rest of the world to get with the program. That’s why it’s so important to celebrate all of the magical women in our lives this Women’s History Month and beyond.Remind your friends how fabulous they are with patriarchy - smashing gifts like catchy cuff bracelets or body - positive wall art.Whether you’re buying from women-owned businesses or brands that are giving back to women,there are so many thoughtful gifts for all of the women who deserve more than one month or day a year.AKA all women.Below, we’ve rounded up 13 gifts for your supportive feminist BFFs, just in time for International Women’s Day:",
                UserId = 1,
                PictureId = 3,
                PostHashtags = { 1, 2 }
            });

            context.Posts.Add(new Post
            {
                Title = "The Best Way To Use Hair Oil, According To Experts",
                SubTitle = "We got the lowdown on this hydrating and styling hair product.",
                Description = "Let’s talk about hair oil, one of the many products out there that promises to give you shiny, healthy, Pantene commercial-worthy hair.It’s typically used to moisturize and hydrate the hair, as well as smooth and protect it from all your styling tools.But hair oil is definitely not a one - size - fits - all product.We spoke to a few hair experts to get the lowdown on all things hair oil,including how to use it.So what’s the point of using hair oil?Our hair is dead once it breaks through the surface of the scalp, as Jasmine Merinsky, a Toronto-based hairstylist, explained to HuffPost.And if it weren’t for our sebaceous glands, which secrete natural oils, that hair would be dry and brittle.“Similar to skin, we need oil to have healthy, strong hair,” Merinsky said. “Oil lubricates the outer cuticle and strengthens the inner core by providing moisture to help keep the bonds strong.”Everyone’s scalp and hair are different and some people are just oilier than others, she added.",
                UserId = 2,
                PictureId = 2,
                PostHashtags = { 1, 2 , 3 }
            });

            context.Comments.Add(new Comment {
                Description = "The best post!",
                PostId = 1,
                UserId = 1
            });

            context.Comments.Add(new Comment
            {
                Description = "The best post!",
                PostId = 2,
                UserId = 2
            });

            context.Comments.Add(new Comment
            {
                Description = "Yess!",
                PostId = 2,
                UserId = 1
            });

            

        }
    }
}

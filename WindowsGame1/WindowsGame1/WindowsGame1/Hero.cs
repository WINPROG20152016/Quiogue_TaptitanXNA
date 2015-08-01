using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsGame1
{
    public class Hero
    {
        #region Properties
        Vector2 PlayerPosition;
        ContentManager content;
        Level level;

        Texture2D idleSprite;
        Texture2D attackSprite;

        Animation idleAnimation;
        Animation attackAnimation;

        AnimationPlayer spritePlayer;

        

        int stateChange = 0;//0 is for idle , 1 is for attack for hero
        public int HeroDamage = 1;//The Total damage done by a certain hero
        public int numSup = 0; //number of support the player has currently
        #endregion 

        public Hero(ContentManager content, Level level)
        {
            this.content = content;
            this.level = level;

        }
        

        public void LoadContent(int choice)
        {
            if (choice == 1)
            {
                idleSprite = content.Load<Texture2D>("HeroAsset/IdleHero");
                attackSprite = content.Load<Texture2D>("HeroAsset/AttackHero");

                idleAnimation = new Animation(idleSprite, 0.2f, true, 4);
                attackAnimation = new Animation(attackSprite, 0.2f, true, 4);

                

                int positionX = 150;
                int positionY = 300;

                PlayerPosition = new Vector2(positionX, positionY);
            }
            else if(choice == 2)
            {
                idleSprite = content.Load<Texture2D>("Support/SpriteSheetSup1");

                idleAnimation = new Animation(idleSprite, 0.2f, true, 3);

                int positionX = 0;
                int positionY = 150;

                PlayerPosition = new Vector2(positionX, positionY);
            }
            else if(choice == 3)
            {
                idleSprite = content.Load<Texture2D>("Support/SpriteSheetSup2");

                idleAnimation = new Animation(idleSprite, 0.2f, true, 3);

                int positionX = 300;
                int positionY = 150;

                PlayerPosition = new Vector2(positionX, positionY);
            }    

            if (stateChange == 0)
            {
                spritePlayer.PlayAnimation(idleAnimation);
            }
            else if(stateChange == 1)
            {
                spritePlayer.PlayAnimation(attackAnimation);
            }

            //spriteSupport.PlayAnimation(supportAnimation);
            //spriteSupport2.PlayAnimation(support2Animation);
            
        }
        public void Update(GameTime gameTime, int choice)
        {
            
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spritePlayer.Draw(gameTime, spriteBatch, PlayerPosition, SpriteEffects.None);
        }
        public void PlayAttack(GameTime gameTime)
        {
            
            if (stateChange == 0)
            {
                stateChange = 1;
                LoadContent(1);
                
                
            }
            else if (stateChange == 1)
            {
                stateChange = 0;
                LoadContent(1);
            }
        }
        public int getDamage(GameTime gameTime)
        {
            return HeroDamage;

        }

    }
}

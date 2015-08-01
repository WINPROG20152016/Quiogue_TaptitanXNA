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
    public class Level
    {
        public static int windowHeight = 500; 
        public static int windowWidth = 400;

        #region Properties
        ContentManager content;

        Texture2D Background;
        Texture2D dmg0;
        Texture2D dmg1;
        Texture2D dmg2;
        Texture2D dmg3;
        Texture2D dmg4;
        Texture2D dmg5;
        Texture2D dmg6;
        Texture2D dmg7;
        Texture2D dmg8;
        Texture2D dmg9;
        Texture2D dmg10;
        Texture2D dmg11;
        Texture2D dmg12;
        Texture2D dmg13;
        Texture2D dmg14;
        Texture2D dmg15;
        Texture2D dmg16;
        Texture2D dmg17;
        Texture2D dmg18;
        Texture2D currentDmg;
        public MouseState oldMouseState;
        public MouseState mouseState;
        bool mpressed, prev_mpressed = false;
        int mouseX, mouseY;

        public int score = 0;
        public int StageNumber = 1;
        public int money = 100;
        public int round = 1;

        Hero hero;
        Hero support1;
        Hero support2;
        Monster monster1;

        SpriteFont damageStringFont;

        Button AttackButton;
        Button upDamage;

        #endregion

        public Level(ContentManager content)
        {
            this.content = content;
            hero = new Hero(content, this);
            support1 = new Hero(content, this);
            support2 = new Hero(content, this);
            monster1 = new Monster(content, this);

        }
        public void LoadContent()
        {
            Background = content.Load<Texture2D>("Background/Background");
            damageStringFont = content.Load<SpriteFont>("font");

            

            #region barAssets
            dmg0 = content.Load<Texture2D>("DamageBar/dmg0");
            dmg1 = content.Load<Texture2D>("DamageBar/dmg1");
            dmg2 = content.Load<Texture2D>("DamageBar/dmg2");
            dmg3 = content.Load<Texture2D>("DamageBar/dmg3");
            dmg4 = content.Load<Texture2D>("DamageBar/dmg4");
            dmg5 = content.Load<Texture2D>("DamageBar/dmg5");
            dmg6 = content.Load<Texture2D>("DamageBar/dmg6");
            dmg7 = content.Load<Texture2D>("DamageBar/dmg7");
            dmg8 = content.Load<Texture2D>("DamageBar/dmg8");
            dmg9 = content.Load<Texture2D>("DamageBar/dmg9");
            dmg10 = content.Load<Texture2D>("DamageBar/dmg1bl");
            dmg11 = content.Load<Texture2D>("DamageBar/dmg2bl");
            dmg12 = content.Load<Texture2D>("DamageBar/dmg3bl");
            dmg13 = content.Load<Texture2D>("DamageBar/dmg4bl");
            dmg14 = content.Load<Texture2D>("DamageBar/dmg5bl");
            dmg15 = content.Load<Texture2D>("DamageBar/dmg6bl");
            dmg16 = content.Load<Texture2D>("DamageBar/dmg7bl");
            dmg17 = content.Load<Texture2D>("DamageBar/dmg8bl");
            dmg18 = content.Load<Texture2D>("DamageBar/dmg9bl");

            #endregion

            AttackButton = new Button(content, "Buttons/Button1", new Vector2(300, 0));
            upDamage = new Button(content, "Buttons/ButtonDmg", new Vector2(0, 400));
            currentDmg = dmg0;

            hero.LoadContent(1);
            //support1.LoadContent(2);
            //support2.LoadContent(3);
            monster1.LoadContent();

            if (hero.numSup == 1)
            {
                support1.LoadContent(2);
            }
            else if(hero.numSup == 2)
            {
                support2.LoadContent(3);
            }
        }
        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            mouseX = mouseState.X;
            mouseY = mouseState.Y;
            prev_mpressed = mpressed;
            mpressed = mouseState.LeftButton == ButtonState.Pressed;



            hero.Update(gameTime, 1);
            monster1.Update(gameTime);
            //support1.Update(gameTime,2);
            //support2.Update(gameTime,3);

           

            if (AttackButton.Update(gameTime, mouseX, mouseY,
                mpressed, prev_mpressed))
            {
                hero.PlayAttack(gameTime);
                monster1.takeDamage(hero.HeroDamage);
                monster1.getHit(gameTime);
          
            }
            if (upDamage.Update(gameTime,mouseX,mouseY,
                mpressed,prev_mpressed))
            {
                //hero.HeroDamage += 1;
                if (upDamage.upButton() <= money)
                {
                    money -= upDamage.upButton();
                    upDamage.curStage += 1;
                    hero.HeroDamage += 1;
                    #region changeBar
                    switch (hero.HeroDamage - 1)
                    {
                        case 0:
                            currentDmg = dmg0;
                            break;
                        case 1:
                            currentDmg = dmg1;
                            break;
                        case 2:
                            currentDmg = dmg2;
                            break;
                        case 3:
                            currentDmg = dmg3;
                            break;
                        case 4:
                            currentDmg = dmg4;
                            break;
                        case 5:
                            currentDmg = dmg5;
                            break;
                        case 6:
                            currentDmg = dmg6;
                            break;
                        case 7:
                            currentDmg = dmg7;
                            break;
                        case 8:
                            currentDmg = dmg8;
                            break;
                        case 9:
                            currentDmg = dmg9;
                            break;
                        case 10:
                            currentDmg = dmg10;
                            break;
                        case 11:
                            currentDmg = dmg11;
                            break;
                        case 12:
                            currentDmg = dmg12;
                            break;
                        case 13:
                            currentDmg = dmg13;
                            break;
                        case 14:
                            currentDmg = dmg14;
                            break;
                        case 15:
                            currentDmg = dmg15;
                            break;
                        case 16:
                            currentDmg = dmg16;
                            break;
                        case 17:
                            currentDmg = dmg17;
                            break;
                        case 18:
                            currentDmg = dmg18;
                            break;
                    #endregion
                    }
                }
            }
            oldMouseState = mouseState;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, Vector2.Zero, Color.White);
            monster1.Draw(gameTime, spriteBatch);
            hero.Draw(gameTime, spriteBatch);

            if (hero.numSup == 1)
            {
                support1.Draw(gameTime, spriteBatch);
            }
            else if(hero.numSup == 2)
            {
                support2.Draw(gameTime, spriteBatch);
            }

            spriteBatch.DrawString(damageStringFont, "Current Hero Damage: " + hero.getDamage(gameTime) + " !", new Vector2(0,30), Color.Black);
            spriteBatch.DrawString(damageStringFont, "Score: " + score, Vector2.Zero, Color.Black);
            spriteBatch.DrawString(damageStringFont, "Money: " + money, new Vector2(150, 0), Color.Black);
            spriteBatch.DrawString(damageStringFont, "HP :  " + monster1.CurHp + "/" + monster1.ToHp, new Vector2(150, windowHeight / 3), Color.Black);
            
            AttackButton.Draw(gameTime, spriteBatch);
            upDamage.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(damageStringFont, "Cost: " + upDamage.upButton() , new Vector2(0, 440), Color.Black); 
            spriteBatch.Draw(currentDmg, new Vector2(88, 400), Color.White);
          
        }
    }
}

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaprak_Kerem_12IT_TD_Game
{
    public class Wave
    {
        Random r = new Random();
        const int delay = 160;
        int counter = 0;
        List<IEnemy> enemiesInWave = new List<IEnemy>();
        List<IEnemy> unSpawnedEnemies = new List<IEnemy>();
        private int enemyRwdAir = 20;
        private int enemyRwdVeh = 40;
        private int enemyRwdGrd = 10;
        private int enemyHthAir = 500;
        private int enemyHthVeh = 800;
        private int enemyHthGrd = 400;
        private int enemyDmgAir = 400;
        private int enemyDmgVeh = 500;
        private int enemyDmgGrd = 100;
        private float enemySpdAir = 0.7f;
        private float enemySpdVeh = 0.4f;
        private float enemySpdGrd = 0.5f;
        public Wave(int enemyAir, int enemyVeh, int enemyGrd, float difficulty, LevelBase lev)
        {
            //update unspawned enemies list based on the numbers of the enemies to add to list
            while(enemyAir != 0 || enemyVeh != 0 || enemyGrd != 0)
            {
                //generate random:
                int n = r.Next(0, 3);
                if(n == 0)  //spawn an air enemy
                {
                    //check if there are still more air enemies to be added to list
                    if(enemyAir != 0)
                    {
                        //add the enemy to list
                        unSpawnedEnemies.Add(new EnemyAir(lev.enemyModelAir,lev.grid, lev, enemyRwdAir - (int)(enemyRwdAir * difficulty), enemyHthAir + (int)(enemyHthAir * difficulty), enemyDmgAir + (int)(enemyDmgAir * difficulty), enemySpdAir + (enemySpdAir * difficulty), this));
                        enemyAir--;
                    }
                    else if(enemyVeh != 0)
                    {
                        unSpawnedEnemies.Add(new EnemyVehicle(lev.enemyModelVehicle, lev.grid, lev, enemyRwdVeh - (int)(enemyRwdVeh * difficulty), enemyHthVeh + (int)(enemyHthVeh * difficulty), enemyDmgVeh + (int)(enemyDmgVeh * difficulty), enemySpdVeh + (enemySpdVeh * difficulty), this));
                        enemyVeh--;
                    }
                    else
                    {
                        unSpawnedEnemies.Add(new EnemyGround(lev.enemyModelGround, lev.grid, lev, enemyRwdGrd - (int)(enemyRwdGrd * difficulty), enemyHthGrd + (int)(enemyHthGrd * difficulty), enemyDmgGrd + (int)(enemyDmgGrd * difficulty), enemySpdGrd + (enemySpdGrd * difficulty), this));
                        enemyGrd--;
                    }
                }
                else if(n == 1) //spawn a vehicle enemy
                {
                    if(enemyVeh != 0)
                    {
                        unSpawnedEnemies.Add(new EnemyVehicle(lev.enemyModelVehicle, lev.grid, lev, enemyRwdVeh - (int)(enemyRwdVeh * difficulty), enemyHthVeh + (int)(enemyHthVeh * difficulty), enemyDmgVeh + (int)(enemyDmgVeh * difficulty), enemySpdVeh + (enemySpdVeh * difficulty), this));
                        enemyVeh--;
                    }
                    else if(enemyAir != 0)
                    {
                        unSpawnedEnemies.Add(new EnemyAir(lev.enemyModelAir, lev.grid, lev, enemyRwdAir - (int)(enemyRwdAir * difficulty), enemyHthAir + (int)(enemyHthAir * difficulty), enemyDmgAir + (int)(enemyDmgAir * difficulty), enemySpdAir + (enemySpdAir * difficulty), this));
                        enemyAir--;
                    }
                    else
                    {
                        unSpawnedEnemies.Add(new EnemyGround(lev.enemyModelGround, lev.grid, lev, enemyRwdGrd - (int)(enemyRwdGrd * difficulty), enemyHthGrd + (int)(enemyHthGrd * difficulty), enemyDmgGrd + (int)(enemyDmgGrd * difficulty), enemySpdGrd + (enemySpdGrd * difficulty), this));
                        enemyGrd--;
                    }
                }
                else //spawn a ground enemy
                {
                    if(enemyGrd != 0)
                    {
                        unSpawnedEnemies.Add(new EnemyGround(lev.enemyModelGround, lev.grid, lev, enemyRwdGrd - (int)(enemyRwdGrd * difficulty), enemyHthGrd + (int)(enemyHthGrd * difficulty), enemyDmgGrd + (int)(enemyDmgGrd * difficulty), enemySpdGrd + (enemySpdGrd * difficulty), this));
                        enemyGrd--;
                    }
                    else if(enemyVeh != 0)
                    {
                        unSpawnedEnemies.Add(new EnemyVehicle(lev.enemyModelVehicle, lev.grid, lev, enemyRwdVeh - (int)(enemyRwdVeh * difficulty), enemyHthVeh + (int)(enemyHthVeh * difficulty), enemyDmgVeh + (int)(enemyDmgVeh * difficulty), enemySpdVeh + (enemySpdVeh * difficulty), this));
                        enemyVeh--;
                    }
                    else
                    {
                        unSpawnedEnemies.Add((new EnemyAir(lev.enemyModelAir, lev.grid, lev, enemyRwdAir - (int)(enemyRwdAir * difficulty), enemyHthAir + (int)(enemyHthAir * difficulty), enemyDmgAir + (int)(enemyDmgAir * difficulty), enemySpdAir + (enemySpdAir * difficulty),this)));
                        enemyAir--;
                    }
                }
            }
        }
        public void update(LevelBase l)
        {
            if (counter >= delay && unSpawnedEnemies.Count() != 0 && !filledPlayersAlready())
            {
                spawnNextEnemy();
                counter = 0;
            }
            //update counter
            counter++;
            //update level enemy list
            l.enemies = enemiesInWave;
        }
        private bool filledPlayersAlready()
        {
            if(enemiesInWave.Count <= 4)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void removeEnemy(IEnemy e)
        {
            enemiesInWave.Remove(e);
        }
        private void spawnNextEnemy() {
            enemiesInWave.Add(unSpawnedEnemies[0]);
            unSpawnedEnemies.RemoveAt(0);
        }
        public bool waveComplete()
        {
            if(enemiesInWave.Count() == 0 && unSpawnedEnemies.Count == 0)
            {
                return true;
            }
            return false;
        }
    }
}

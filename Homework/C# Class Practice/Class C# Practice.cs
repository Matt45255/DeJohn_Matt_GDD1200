using System;

//Rules of war:
//two players draw a card
//the higher card wins
//however, if there is a draw
//draw again
//war is driven by the game class
//ace is high

//now I would like a battle simulator that takes two variables, 
//attack and hp, and uses those variables to determine who wins at combat
//the goal is to have a warrior class that has high HP and low damage
//and a wizard class with low HP and high damage.
//Also, their damage is random and the battle continues until one is dead

public class Game {


    
    //main is where everything begins, we should have minimal code here
    //statis is big and scary because everything can see it, ensure
    //your function needs to be static otherwise it can cause
    //amazing and hilarious issues
    public static void Main(string[] args) {

        Wizard wiz = new Wizard();
        Console.WriteLine(wiz.getHP());
        wiz.setNum(30);
        Console.WriteLine(wiz.getNum());
        //Player play2 = new Player();
        //Console.WriteLine(play2.getNum());
        //now I have two instances of the player class I can use for a game
        //create a new instance of game
        Game game = new Game();
        //game.warGame(play1, play2);
    }
    //we can send objects as parameters
    public int warGame(Player play1, Player play2){
        if(play1.getNum() == play2.getNum()){
            Console.WriteLine("It is a draw");
        }
        else if(play2.getNum() > play1.getNum() ){
            Console.WriteLine("Player 2 wins");
        }
        else{
            Console.WriteLine("Player 1 wins");
        }
        
        return 1;
    }
    
}
//classes in general are used to be able to have data you can control
//why we are making the class public is so it is accessible to other classes within the project
public abstract class Player{
    private int numGen;//damage in the D&D game, value in war game
    private int HP;//HP, if this is < 0, you lose
    Random rnd = new Random();
    //player constructor
    public Player(){
            //generating random number for value
            numGen = rnd.Next(2, 14);
    }
    //getting the generated number
    public int getNum(){
        return numGen;
    }
    //setting the number
    public void setNum(int new_Num){
        numGen = new_Num;
    }
    //getting the generated number
    public int getHP(){
        return HP;
    }
    //setting the number
    public void setHP(int new_HP){
        HP = new_HP;
    }
    //generate a new number
    public void newNum(int new_Num_Base, int new_Num_Range)
    {
        //generating a new value for attack
        numGen = rnd.Next(new_Num_Base, new_Num_Range);
    }    
    public abstract void specialattack();
}
//this is the punchline to why we are studying this at all
//inheritance is enormous in programming, why?
//imagine if I had you make players for every single idea I had
//not only that, imagine if they all had to share the exact same information
//so my warrior has to keep track of whether or not he can cast spells
//the wizard needs to be told they cannot take warrior feats, etc.
//This is wildly inefficient

//every time I create a fighter, I create a player along with alll the good stuff I programmed for it
public class Fighter : Player{
    //the fighter has higher base damage, but lower potential damage
    public Fighter(){
        //created the hitpoints for the warrior
        setHP(40);
        //set damage range
        newNum(5, 20);
    }
   //Now in the fighter class, we can use a special attack
    public override void specialattack(){
        int newDamage = getNum()*2;
        setNum(newDamage);
    }
}
public class Wizard: Player{
    //the wizard has higher potential damage but lower base
    public Wizard(){
        //created the hitpoints for the warrior
        setHP(30);
        //set damage range
        newNum(1, 40);
    }
       //Now in the wizard class, we can use a special attack
    public override void specialattack(){
        int newDamage = getNum()*2;
        setNum(newDamage);
    }
}
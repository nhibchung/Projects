package edu.geog.ucsb.twitterproject;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;

public class SentimentAnalyzer {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		// Sentiment score : "Very Negative","Negative", "Neutral", "Positive", "Very Positive"
		//                         -2            -1          0          1             2
		
		String line =  null;
		BufferedReader bReader = null;
		NLP.init();
			
		try{
			PrintWriter pWriter = new PrintWriter(new BufferedWriter(new FileWriter("..\\scoredCumulativeTweetData.csv", true)));
			
			try{
				bReader = new BufferedReader(new FileReader("..\\cumulativeServerTweetData.csv"));
					while((line=bReader.readLine())!=null){
					    String strArray[] = line.split(",");
					    String tweet = strArray[2];				 	
					    pWriter.write(line + "," + (NLP.findSentiment(tweet)-2) + "\n");
					    //System.out.println(tweet +NLP.findSentiment(tweet) );

					}		
					
			} 
			finally{
				bReader.close();
				pWriter.close();
			}			
		} catch (IOException e) {
			e.printStackTrace();
		}
    	System.out.println("Done scoring tweets!");
	}	
}

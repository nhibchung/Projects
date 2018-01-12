package edu.geog.ucsb.gisproject;
import java.io.BufferedWriter;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.UnsupportedEncodingException;

import twitter4j.FilterQuery;
import twitter4j.StallWarning;
import twitter4j.Status;
import twitter4j.StatusDeletionNotice;
import twitter4j.StatusListener;
import twitter4j.TwitterStream;
import twitter4j.TwitterStreamFactory;
import twitter4j.conf.ConfigurationBuilder;

	public class gisTweetStream {
	    public static void main(String[] args) {
	    	ConfigurationBuilder cb = new ConfigurationBuilder();
	        cb.setDebugEnabled(true);
	        cb.setOAuthConsumerKey("###");
	        cb.setOAuthConsumerSecret("###");
	        cb.setOAuthAccessToken("###");
	        cb.setOAuthAccessTokenSecret("###");

	        TwitterStream twitterStream = new TwitterStreamFactory(cb.build()).getInstance();
			//	Desired fields:	        
			//        	{
			//    		"createdAt" (time)
			//    		"id"  (tweetID)
			//    		"text"
			//    		"source"
			//    		 "geoLocation": {
			//    		    "latitude": 
			//    		    "longitude": 
			//    		  },
			//    		}
			//    		"user": {
			//    		"id" (UserID)
			//    		}

	        final String path = "serverTweetData.csv";
			StringBuilder header = new StringBuilder();
    		header.append("id,createdAt,text,source,latitude,longitude,userId\n");
    		
            try (PrintWriter writer = new PrintWriter(new BufferedWriter(new FileWriter(path, true)))){ 
				writer.write(header.toString());
			} catch (FileNotFoundException e) {
				e.printStackTrace();
			} catch (UnsupportedEncodingException e) {
				e.printStackTrace();
			} catch (IOException e) {
				e.printStackTrace();
           	}
    		
	        StatusListener listener = new StatusListener() {
	
	            @Override
	            public void onException(Exception arg0) {
	                // TODO Auto-generated method stub

	            }

	            @Override
	            public void onDeletionNotice(StatusDeletionNotice arg0) {
	                // TODO Auto-generated method stub

	            }

	            @Override
	            public void onScrubGeo(long arg0, long arg1) {
	                // TODO Auto-generated method stub

	            }

	            @Override
	            public void onStatus(Status status) {
	                //User user = status.getUser();
	                
	            	if(status.getGeoLocation()!=null){            	
	                	String statusText = status.getText().toLowerCase();
	                	
	                	// regex : checking if keyword is at beginning or end and see if it's a stand-alone word
	                			//Democrats
	                	if(statusText.matches(".*\\bjoe biden\\b.*")
	                			||statusText.matches(".*\\bhillary clinton\\b.*")||statusText.matches(".*\\bhilary clinton\\b.*")
	                			||statusText.matches(".*\\blincoln chafee\\b.*")||statusText.matches(".*\\bmartin o'malley\\b.*")
	                			||statusText.matches(".*\\bbernie sanders\\b.*")||statusText.matches(".*\\bjim webb\\b.*")
	                			
	                			//Republicans 
	                			||statusText.matches(".*\\bted cruz\\b.*")||statusText.matches(".*\\bjeb bush\\b.*")
	                			||statusText.matches(".*\\bjohn bolton\\b.*")||statusText.matches(".*\\bben carson\\b.*")
	                			||statusText.matches(".*\\bchris christie\\b.*")||statusText.matches(".*\\bbob ehrlich\\b.*")
	                			||statusText.matches(".*\\bmark everson\\b.*")||statusText.matches(".*\\bcarly fiorina\\b.*")
	                			||statusText.matches(".*\\bjim gilmore\\b.*")||statusText.matches(".*\\blindsey graham\\b.*")
	                			||statusText.matches(".*\\bmike huckabee\\b.*")||statusText.matches(".*\\bbobby jindal\\b.*")
	                			||statusText.matches(".*\\bjohn kasich\\b.*")||statusText.matches(".*\\bpete king\\b.*")
	                			||statusText.matches(".*\\bsarah palin\\b.*")||statusText.matches(".*\\bgeorge pataki\\b.*")
	                			||statusText.matches(".*\\brand paul\\b.*")||statusText.matches(".*\\bmike pence\\b.*")
	                			||statusText.matches(".*\\brick perry\\b.*")||statusText.matches(".*\\bmarco rubio\\b.*")
	                			||statusText.matches(".*\\brick santorum\\b.*")||statusText.matches(".*\\brick snyder\\b.*")
	                			||statusText.matches(".*\\bscott walker\\b.*")
	                			){
	                		
	            			StringBuilder csvString = new StringBuilder();
	            			
	                		csvString.append(status.getId()).append(",");
	                		csvString.append(status.getCreatedAt()).append(",");
	                		csvString.append(status.getText().replace(",", "")).append(",");
	                		csvString.append(status.getSource()).append(",");
	                		csvString.append(status.getGeoLocation().getLatitude()).append(",");
	                		csvString.append(status.getGeoLocation().getLongitude()).append(",");
	                		csvString.append(status.getUser().getId()).append(",");
	                		
	                		// 6 declared or potential democrats; added columns for name and party
	                		if(statusText.matches(".*\\bjoe biden\\b.*")) {
	                			csvString.append("joe biden,").append("democrat,");
	                		}
	                		if(statusText.matches(".*\\bhillary clinton\\b.*")||statusText.matches(".*\\bhilary clinton\\b.*")) {
	                			csvString.append("hillary clinton,").append("democrat,");
	                		}
	                		if(statusText.matches(".*\\blincoln chafee\\b.*")) { 
	                			csvString.append("lincoln chafee,").append("democrat,");
	                		}
	                		if(statusText.matches(".*\\bmartin o'malley\\b.*")) {
	                			csvString.append("martin o'malley,").append("democrat,");
	                		}
	                		if(statusText.matches(".*\\bbernie sanders\\b.*")) {
	                			csvString.append("bernie sanders,").append("democrat,");
	                		}
	                		if(statusText.matches(".*\\bjim webb\\b.*")) {
	                			csvString.append("jim webb,").append("democrat,");
	                		}
	                		
	                		// 23 declared or potential republicans; added columns for name and party
	                		if(statusText.matches(".*\\bted cruz\\b.*")) {
	                			csvString.append("ted cruz,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bjeb bush\\b.*")) {
	                			csvString.append("jeb bush,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bjohn bolton\\b.*")) {
	                			csvString.append("john bolton,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bben carson\\b.*")) {
	                			csvString.append("ben carson,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bchris christie\\b.*")) {
	                			csvString.append("chris christie,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bbob ehrlich\\b.*")) {
	                			csvString.append("bob ehrlich,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bmark everson\\b.*")) {
	                			csvString.append("mark everson,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bcarly fiorina\\b.*")) {
	                			csvString.append("carly fiorina,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bjim gilmore\\b.*")) {
	                			csvString.append("jim gilmore,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\blindsey graham\\b.*")) {
	                			csvString.append("lindsey graham,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bmike huckabee\\b.*")) {
	                			csvString.append("mike huckabee,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bbobby jindal\\b.*")) {
	                			csvString.append("bobby jindal,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bjohn kasich\\b.*")) {
	                			csvString.append("john kasich,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bpete king\\b.*")) {
	                			csvString.append("pete king,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bsarah palin\\b.*")) {
	                			csvString.append("sarah palin,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bgeorge pataki\\b.*")) {
	                			csvString.append("george pataki,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\brand paul\\b.*")) {
	                			csvString.append("rand paul,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bmike pence\\b.*")) {
	                			csvString.append("mike pence,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\brick perry\\b.*")) {
	                			csvString.append("rick perry,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bmarco rubio\\b.*")) {
	                			csvString.append("marco rubio,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\brick santorum\\b.*")) {
	                			csvString.append("rick santorum,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\brick snyder\\b.*")) {
	                			csvString.append("rick snyder,").append("republican,");
	                		}
	                		if(statusText.matches(".*\\bscott walker\\b.*")) {
	                			csvString.append("scott walker,").append("republican,");
	                		}
	                		
	                		csvString.append("\n");                		
	                		
			                try (PrintWriter writer = new PrintWriter(new BufferedWriter(new FileWriter(path, true)))){ 
			    				writer.write(csvString.toString());
			    			} catch (FileNotFoundException e) {
			    				e.printStackTrace();
			    			} catch (UnsupportedEncodingException e) {
			    				e.printStackTrace();
			    			} catch (IOException e) {
			    				e.printStackTrace();
			               	}
	                	}
	            	}		 
	            }
	            	

	            @Override
	            public void onTrackLimitationNotice(int arg0) {
	                // TODO Auto-generated method stub

	            }

				@Override
				public void onStallWarning(StallWarning arg0) {
					// TODO Auto-generated method stub
					
				}

	        };
	        
	        twitterStream.addListener(listener);
	        FilterQuery fq = new FilterQuery();
	    

	        //bounding box for US
	        double[][] bbLocations = {{-179.15,18.91},{-66.94,71.44}};
	        fq.locations(bbLocations); 
	        twitterStream.filter(fq);  
	        
	    }
	}

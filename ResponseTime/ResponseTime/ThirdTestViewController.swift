//
//  ThirdTestViewController.swift
//  ResponseTime
//
//  Created by Jesper Østergaard on 17/02/2016.
//  Copyright © 2016 Jesper Østergaard. All rights reserved.
//

import UIKit

class ThirdTestViewController: UIViewController {

    var delay = 0.0
    
    //saved data
    var savedData : [Double] = []
    
    var currentImage = "image1.jpg"
    @IBOutlet weak var image: UIImageView!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        //Load saved data
        if NSUserDefaults.standardUserDefaults().objectForKey("TestThirdPerformance") != nil {
            savedData = NSUserDefaults.standardUserDefaults().objectForKey("TestThirdPerformance") as! [Double]
        }
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
    }
    
    @IBAction func toSlow(sender: AnyObject) {
        savedData.append(delay)
        NSUserDefaults.standardUserDefaults().setObject(savedData, forKey: "TestThirdPerformance")
        delay = 0
        
        //Show alert box
        let alert = UIAlertController(title: "Thank you", message: "Your data has been saved, and the delay has been reset to 0", preferredStyle: UIAlertControllerStyle.Alert)
        alert.addAction(UIAlertAction(title: "OK", style: .Default, handler: { (action) -> Void in
            
            //self.dismissViewControllerAnimated(true, completion: nil)
            
        }))
        
        self.presentViewController(alert, animated: true, completion: nil)
    }

    @IBAction func switchImage(sender: AnyObject) {
        if currentImage == "image1.jpg"{
            currentImage = "image2.jpg"
        }else{
            currentImage = "image1.jpg"
        }
        
        let delay_nano = delay * Double(NSEC_PER_SEC)  // nanoseconds per seconds
        let dispatchTime = dispatch_time(DISPATCH_TIME_NOW, Int64(delay_nano))
        
        dispatch_after(dispatchTime, dispatch_get_main_queue(), {
            self.delay = self.delay + 0.1
            self.image.image = UIImage(named: self.currentImage)
        })
        
    }

}

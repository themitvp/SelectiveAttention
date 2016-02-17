//
//  ClickItem.swift
//  ResponseTime
//
//  Created by Jesper Østergaard on 17/02/2016.
//  Copyright © 2016 Jesper Østergaard. All rights reserved.
//

import Foundation

class ClickItem:  NSObject, NSCoding  {
    var delay: Double!
    var secondsBeforeClick: Double!
    var username: NSString!
    var date : NSDate!
    
    init(delay: Double, secondsBeforeClick: Double, username: NSString, date : NSDate) {
        self.delay = delay
        self.secondsBeforeClick = secondsBeforeClick
        self.username = username
        self.date = date
        
    }
    
    required convenience init(coder aDecoder: NSCoder) {
        //let id = aDecoder.decodeIntegerForKey("id")
        let delay = aDecoder.decodeObjectForKey("delay") as! Double
        let secondsBeforeClick = aDecoder.decodeObjectForKey("secondsBeforeClick") as! Double
        let username = aDecoder.decodeObjectForKey("username") as! String
        let date = aDecoder.decodeObjectForKey("date") as! NSDate
        
        self.init(delay: delay, secondsBeforeClick: secondsBeforeClick, username: username, date : date)
    }
    
    func encodeWithCoder(aCoder: NSCoder) {
        //aCoder.encodeInteger(id, forKey: "id")
        aCoder.encodeObject(delay, forKey: "delay")
        aCoder.encodeObject(secondsBeforeClick, forKey: "secondsBeforeClick")
        aCoder.encodeObject(username, forKey: "username")
        aCoder.encodeObject(date, forKey: "date")
    }
}
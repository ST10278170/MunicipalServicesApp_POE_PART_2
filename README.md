# MunicipalServicesApp_POE_PART_2

YouTube Link - 


Overview

The Municipal Services Application is a Windows Forms application developed to improve communication between community members and municipal services. The system allows residents to report municipal issues, manage submitted reports, and access information about local events and announcements.This repository represents the completion of POE Part 2, which builds upon the functionality developed in Part 1 by introducing a Local Events and Announcements module together with advanced data structures and recommendation features.

Part 2 Features
Local Events and Announcements

A dedicated section has been added to display municipal events and community announcements.

Users can:
View upcoming events
Search events by category
Search events by date
View event details
Receive event recommendations
Event Categories

Examples include:
Community
Health
Sports
Infrastructure
Safety


Used to maintain the user's most recent search categories.

Purpose:
Tracks search history
Supports recommendation generation
HashSet
C#
HashSet<string>

Used to store event categories.

Purpose:
Prevents duplicate categories
Populates category selections efficiently
Dictionary
C#
Dictionary<string, EventItem>

Used for fast event lookups.

Purpose:
Retrieve event information quickly
Display event details efficiently

A second dictionary is used to track:

C#
Dictionary<string, int>

Purpose:
Count category searches
Determine user preferences
SortedDictionary
C#
SortedDictionary<DateTime, List<EventItem>>

Purpose:
Organise events by date
Display events chronologically
Recommendation Engine

The application records category searches made by the user.

Based on the most frequently searched category:

User preferences are analysed
Related events are identified
Recommendations are displayed automatically

Example:
Plain Text
Health
Health
Sports
Health

The application identifies:
Plain Text
Health

as the preferred category and recommends health-related events.



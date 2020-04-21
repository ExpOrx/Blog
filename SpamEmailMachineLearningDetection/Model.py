#!/usr/bin/env python
# -*- coding:utf-8 -*-
import os
import random
from collections import Counter
from nltk import word_tokenize, NaiveBayesClassifier, classify, data
from nltk.corpus import stopwords
from nltk.stem.wordnet import WordNetLemmatizer


def init_emails(folder_path):
    emails_path = []
    for path in os.listdir(folder_path):
        path = data.find(os.path.join(folder_path, path))
        raw = open(path,'rU',encoding = 'ISO-8859-1').read()
        emails_path.append(raw)
    return emails_path

def get_all_emails(emails_result,tag):
    return [(email, tag) for email in emails_result]

def emails_shuffle(all_emails):
    return random.shuffle(all_emails)

def preprocess(sentence):
    lemmatizer = WordNetLemmatizer()
    return [lemmatizer.lemmatize(word.lower()) for word in word_tokenize(sentence)]

stoplist = stopwords.words('english')

def get_features(text,setting):
    if setting == 'bow':
        return {word: count for word, count in Counter(preprocess(text)).items() if not word in stoplist}
    else:
        return {word: True for word in preprocess(text) if not word in stoplist}

def get_classifier(all_features):
    size = int(len(all_features) * 0.8)
    train_set, test_set = all_features[size:], all_features[:size]
    classifier = NaiveBayesClassifier.train(train_set)
    return classifier,train_set, test_set

def evalute(classifier, train_set,test_set):
    print('Accuracy on the training set = ' + str(classify.accuracy(classifier, train_set)))
    print('Accuracy on the test set = ' + str(classify.accuracy(classifier, test_set)) + '\n')

def main():
    spam = init_emails('ML/SpamEmail/enron1/spam/')
    ham = init_emails('ML/SpamEmail/enron1/ham/')

    all_emails = get_all_emails(spam,'spam')+get_all_emails(ham,'ham')

    emails_shuffle(all_emails)

    all_features = [(get_features(email, 'bow'), label) for (email, label) in all_emails]

    classifier,train_set, test_set = get_classifier(all_features)

    evalute(classifier, train_set, test_set)



if __name__ == '__main__':
    main()


